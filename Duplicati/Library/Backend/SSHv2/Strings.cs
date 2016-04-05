using Duplicati.Library.Localization.Short;
namespace Duplicati.Library.Backend.Strings {
    internal static class KeyGenerator {
        public static string Description { get { return LC.L(@"Module for generating SSH private/public keys"); } }
        public static string DisplayName { get { return LC.L(@"SSH Key Generator"); } }
        public static string KeyUsernameShort { get { return LC.L(@"Public key username"); } }
        public static string KeyUsernameLong { get { return LC.L(@"A username to append to the public key"); } }
        public static string KeyTypeShort { get { return LC.L(@"The key type"); } }
        public static string KeyTypeLong { get { return LC.L(@"Determines the type of key to generate"); } }
        public static string KeyLenShort { get { return LC.L(@"The key length"); } }
        public static string KeyLenLong { get { return LC.L(@"The length of the key in bits"); } }
    }
    internal static class KeyUploader {
        public static string Description { get { return LC.L(@"Module for uploading SSH public keys"); } }
        public static string DisplayName { get { return LC.L(@"SSH Key Uploader"); } }
        public static string UrlShort { get { return LC.L(@"The SSH connection URL"); } }
        public static string UrlLong { get { return LC.L(@"The SSH connection URL used to establish the connection"); } }
        public static string PubkeyShort { get { return LC.L(@"The SSH public key to append"); } }
        public static string PubkeyLong { get { return LC.L(@"The SSH public key must be a valid SSH string, which is appended to the .ssh/authorized_keys file"); } }
    }
    internal static class SSHv2Backend {
        public static string Description { get { return LC.L(@"This backend can read and write data to an SSH based backend, using SFTP. Allowed formats are ""ssh://hostname/folder"" or ""ssh://username:password@hostname/folder""."); } }
        public static string DescriptionAuthPasswordLong { get { return LC.L(@"The password used to connect to the server. This may also be supplied as the environment variable ""AUTH_PASSWORD""."); } }
        public static string DescriptionAuthPasswordShort { get { return LC.L(@"Supplies the password used to connect to the server"); } }
        public static string DescriptionAuthUsernameLong { get { return LC.L(@"The username used to connect to the server. This may also be supplied as the environment variable ""AUTH_USERNAME""."); } }
        public static string DescriptionAuthUsernameShort { get { return LC.L(@"Supplies the username used to connect to the server"); } }
        public static string DescriptionSshkeyfileLong { get { return LC.L(@"Points to a valid OpenSSH keyfile. If the file is encrypted, the password supplied is used to decrypt the keyfile.  If this option is supplied, the password is not used to authenticate. This option only works when using the managed SSH client."); } }
        public static string DescriptionSshkeyfileShort { get { return LC.L(@"Uses a SSH private key to authenticate"); } }
        public static string DescriptionSshkeyLong(string urlprefix) { return LC.L(@"An url-encoded SSH private key. The private key must be prefixed with {0}. If the file is encrypted, the password supplied is used to decrypt the keyfile.  If this option is supplied, the password is not used to authenticate. This option only works when using the managed SSH client.", urlprefix); }
        public static string DescriptionSshkeyShort { get { return LC.L(@"Uses a SSH private key to authenticate"); } }
        public static string DisplayName { get { return LC.L(@"NBI via SSH"); } }
        public static string FolderNotFoundManagedError(string foldername, string message) { return LC.L(@"Unable to set folder to {0}, error message: {1}", foldername, message); }
    }
}
