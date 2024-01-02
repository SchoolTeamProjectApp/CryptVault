namespace CryptVault.Core.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string data);
        string Decrypt(string data);
    }
}