namespace WebApiStarter.Commons.ModelValidation
{
    public class ValidationError
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return (string.Format("{0} -{1}", Name, Message.Split(':')[1].Split('.')[0]));
        }
    }
}