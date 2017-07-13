namespace Talkative.Models.Response{
    public abstract class BaseResponse{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set;}
    }
}