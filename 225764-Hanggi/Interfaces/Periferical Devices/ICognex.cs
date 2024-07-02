namespace HMI.Interfaces
{
    interface ICognex
    {
        void OpenConnection();
        void CloseConnection();
        string CheckConnection();
    }
}
