namespace Standard_Api_Response {
    public class StandardResponseMessages {
        public static string OK => SUCCESSFUL;
        public static string PASSWORD_RESET_EMAIL_SENT = "An email has been sent to you with instructions and next steps";
        public static string SUCCESSFUL = "Successful";
        public static string UNSUCCESSFUL = "Unsuccessful";
        public static string ERROR_OCCURRED = "An error occurred, please try again later";
        public static string RESOURCE_NOT_FOUND = "The resource requested could not be found.";
        public static string RESOURCE_DEELETED = "The resource has been deleted successfully.";
        public static string RESOURCE_ALREADY_EXIST = "The resource with the same information already exist.";
        public static string EMAIL_VERIFIED = "Email verification successful";
        public static string ALREADY_ACTIVATED = "Email already verified";
        public static string EMAIL_VERIFICATION_FAILED =
            "Email verification failed. This Link may have expired please contact admin";
        public static string USER_NOT_FOUND = "User with this email does not exist";
        public static string PASSWORD_RESET_FAILED =
            "Password reset failed. This Link may have expired please contact admin";
        public static string PASSWORD_RESET_COMPLETE = "Your password has been reset successfully";
        public static string MEDIA_UPLOAD_FAILED = "We encountered an error uploading this media at this time";
        public static string MEDIA_UPLOAD_SUCCESSFUL = "Media Uploaded successfully";
    }
}
