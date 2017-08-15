namespace Talkative{
    public class TelegramBaseResponse<T>{
        public bool Ok { get; set; }
        public T Result { get; set; }   
    }
}