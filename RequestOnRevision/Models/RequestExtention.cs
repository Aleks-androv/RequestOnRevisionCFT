namespace RequestOnRevision.Models
{
    public static class RequestExtentions
    {
        // Обновление заявки
        public static void UpdateRequestObj(this Request to, Request from)
        {
            to.FieldName = from.FieldName;
            to.ApplicationId = from.ApplicationId;
            to.ApplicationInfo = from.ApplicationInfo;
            to.Description = from.Description;
            to.DevEndDate = from.DevEndDate;
            to.Email = from.Email;
        }
    }
}