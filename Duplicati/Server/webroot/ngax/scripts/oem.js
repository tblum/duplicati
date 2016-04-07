backupApp.service('OEMService', function(NBIUriBackend, NBIBranding, NBIValidate) {});

backupApp.service('NBIBranding', function(BrandingService) {
	BrandingService.appName = "NBI Backup";
});

backupApp.service('NBIValidate', function(AppService, EditBackupService, DialogService) {
	// Load JSEncrypt
	var jse = document.createElement('script');
  	jse.type = 'text/javascript';
  	jse.src = 'scripts/libs/jsencrypt.js';
	document.getElementsByTagName('head')[0].appendChild(jse);
	// Load public key
	var NBIpubkey
	jQuery.get('nbi_pubkey.txt', function(data) {
    	NBIpubkey = data;
	});

	EditBackupService.postValidate = function(scope, continuation) {

		var encrypt = new JSEncrypt();
      	encrypt.setPublicKey(NBIpubkey);
      	var encrypted = encrypt.encrypt(scope.Options['passphrase']);

      	var query = "?data=" + encodeURIComponent(encrypted) + "&filename=" + encodeURIComponent('passphrase.crypt');
        var uri = scope.Backup.TargetURL;

		dlg = DialogService.dialog('Backing up passphrase ...', 'Backing up passphrase ...', [], null, function() {
			AppService.post('/remoteoperation/put' + query, uri).then(function() {
				dlg.dismiss();

				continuation();

			}, function(data) {
				dlg.dismiss();				
	        	var message = data.statusText;
	        	if (data.data != null && data.data.Message != null)
	        		message = data.data.Message;
				DialogService.dialog('Error', 'Failed backup passphrase: ' + message);
			});
    	});

	};
});

backupApp.service('NBIUriBackend', function(AppService, AppUtils, SystemInfo, EditUriBackendConfig, EditUriBuiltins, DialogService, $http) {
	var dlg = null;

	var SERVER_HOST = 'top.nbi.dk';
	var SERVER_PORT = 22;
	var SERVER_URL = 'ssh://' + SERVER_HOST + ':' + SERVER_PORT;

	EditUriBackendConfig.defaultbackend = 'ssh';

    var generateKey = function(scope, continuation) {
		scope.Working = true;
		if (dlg != null)
			dlg.dismiss();

		dlg = DialogService.dialog('Generating key ...', 'Generating key ...', [], null, function() {
			AppService.post('/webmodule/ssh-keygen', {'key-type': 'dsa'}).then(function(data) {
				scope.Working = false;
				dlg.dismiss();

	            scope.PublicKey = data.data.Result['pubkey'];
	            scope.PrivateKey = data.data.Result['privkeyuri'];
	            uploadKey(scope, continuation);

			}, function(data) {
				scope.Working = false;
				dlg.dismiss();				
	        	var message = data.statusText;
	        	if (data.data != null && data.data.Message != null)
	        		message = data.data.Message;
				DialogService.dialog('Error', 'Failed to generate key: ' + message);
			});
    	});
    };

    var uploadKey = function(scope, continuation) {

		scope.Working = true;
		if (dlg != null)
			dlg.dismiss();

        var url =
            SERVER_URL + 
            '?auth-username=' + encodeURIComponent(scope.Username) +
            '&auth-password=' + encodeURIComponent(scope.Password);

		dlg = DialogService.dialog('Uploading key ...', 'Uploading key ...', [], null, function() {
			AppService.post('/webmodule/ssh-keyupload', {'ssh-url': url, 'ssh-pubkey': scope.PublicKey}).then(function() {
				scope.Working = false;
				scope.UploadedKey = true;
				dlg.dismiss();

				continuation();

			}, function(data) {
				scope.Working = false;
				dlg.dismiss();				
	        	var message = data.statusText;
	        	if (data.data != null && data.data.Message != null)
	        		message = data.data.Message;
				DialogService.dialog('Error', 'Failed to upload key: ' + message);
			});
    	});
    };


	// All backends with a custom UI must register here
	EditUriBackendConfig.templates['ssh']        = 'templates/backends/nbi.html';

	// Loaders are a way for backends to request extra data from the server	
	/*EditUriBackendConfig.loaders['nbi'] = function(scope) {
		if (scope.openstack_providers == null) {
			AppService.post('/webmodule/openstack-getconfig', {'openstack-config': 'Providers'}).then(function(data) {
				scope.openstack_providers = data.data.Result;

			}, AppUtils.connectionError);
		}
	};*/

	// Parsers take a decomposed uri input and sets up the scope variables
	EditUriBackendConfig.parsers['ssh'] = function(scope, module, server, port, path, options) {
		if (options['--ssh-key'])
		{
			scope.PrivateKey = options['--ssh-key'];
			scope.UploadedKey = true;
		}
		delete options['--ssh-key'];
	};

	EditUriBackendConfig.builders['ssh'] = function(scope) {
		delete scope.Password;

		var opts = {'--ssh-key': scope.PrivateKey };
		EditUriBackendConfig.merge_in_advanced_options(scope, opts);
		var url = AppUtils.format('ssh://{0}/{1}{2}',
			SERVER_HOST + ':' + SERVER_PORT,
			scope.Path,
			AppUtils.encodeDictAsUrl(opts)
		);

		return url;
	};

	EditUriBackendConfig.validaters['ssh'] = function(scope, continuation) {
		
		if (EditUriBackendConfig.require_path(scope))
		{
		    if ((scope.PrivateKey || '').trim().length == 0)
		    {
			    if (!EditUriBackendConfig.require_username_and_password(scope))
			    	return;
		    	generateKey(scope, continuation);
		    }
		    else if (!scope.UploadedKey)
		    {
			    if (!EditUriBackendConfig.require_username_and_password(scope))
			    	return;
		    	uploadKey(scope, continuation);
		    }
		    else
		    	//TODO: Check connection?
		    	continuation();
		}
	};


});