namespace LibraryManagementSystem.WEB.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSucces = true, string message = "")
        {
            IsSucces = isSucces;
            Message = message;
        }

        public bool IsSucces { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Success() => new();
        public static ResultViewModel Error(string message) => new(false, message);
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSucces = true, string message = "")
        : base(isSucces, message)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data) => new(data);
        public static ResultViewModel<T> Error(string message) => new(default, false, message);



    }
}
