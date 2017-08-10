using System;
using LoginScreen;

public class CredentialsProvider : ICredentialsProvider
{
	// Constructor without parameters is required

	public bool NeedLoginAfterRegistration
	{
		get
		{
			// If you want your user to login after he/she has been registered
			return true;

			// Otherwise you can:
			// return false;
		}
	}

	public void Login(string userName, string password, Action successCallback, Action<LoginScreenFaultDetails> failCallback)
	{
		// Do some operations to login user

		// If login was successfully completed
		successCallback();

		// Otherwise
		// failCallback(new LoginScreenFaultDetails {
		//  CommonErrorMessage = "Some error message relative to whole form",
		//  UserNameErrorMessage = "Some error message relative to user name form field",
		//  PasswordErrorMessage = "Some error message relative to password form field"
		// });
	}

	public void Register(string email, string userName, string password, Action successCallback, Action<LoginScreenFaultDetails> failCallback)
	{
		// Do some operations to register user

		// If registration was successfully completed
		successCallback();

		// Otherwise
		// failCallback(new LoginScreenFaultDetails {
		//  CommonErrorMessage = "Some error message relative to whole form",
		//  EmailErrorMessage = "Some error message relative to e-mail form field",
		//  UserNameErrorMessage = "Some error message relative to user name form field",
		//  PasswordErrorMessage = "Some error message relative to password form field"
		// });
	}

	public void ResetPassword(string email, Action successCallback, Action<LoginScreenFaultDetails> failCallback)
	{
		// Do some operations to reset user's password

		// If password was successfully reset
		successCallback();

		// Otherwise
		// failCallback(new LoginScreenFaultDetails {
		//  CommonErrorMessage = "Some error message relative to whole form",
		//  EmailErrorMessage = "Some error message relative to e-mail form field"
		// });
	}

	public bool ShowPasswordResetLink
	{
		get
		{
			// If you want your login screen to have a forgot password button
			return true;

			// Otherwise you can:
			// return false;
		}
	}

	public bool ShowRegistration
	{
		get
		{
			// If you want your login screen to have a register new user button
			return true;

			// Otherwise you can:
			// return false;
		}
	}
}
public class LoginScreenMessages : ILoginScreenMessages
{
    // Constructor without parameters is required

    // There must be placed properties that returns some sctrings to use it to display
    public string LoginFormTitle => "nuevooooo";

    public string UserNameFieldPlaceHolder => "nuevooooo";

    public string PasswordFieldPlaceHolder => throw new NotImplementedException();

    public string LogInButtonTitle => throw new NotImplementedException();

    public string ForgotPasswordButtonTitle => throw new NotImplementedException();

    public string OrLabelText => throw new NotImplementedException();

    public string RegisterSuggesionLabelText => throw new NotImplementedException();

    public string RegisterButtonTitle => throw new NotImplementedException();

    public string ResetPasswordFormTitle => throw new NotImplementedException();

    public string EmailFieldPlaceHolder => throw new NotImplementedException();

    public string ResetButtonTitle => throw new NotImplementedException();

    public string RegistrationFormTitle => throw new NotImplementedException();

    public string PasswordConfirmationFieldPlaceHolder => throw new NotImplementedException();

    public string ErrorMessageEmailRequired => throw new NotImplementedException();

    public string ErrorMessageEmailInvalid => throw new NotImplementedException();

    public string ErrorMessageUserNameRequired => throw new NotImplementedException();

    public string ErrorMessagePasswordRequired => throw new NotImplementedException();

    public string ErrorMessagePasswordDoesNotMatch => throw new NotImplementedException();

    public string LoginWaitingMessage => throw new NotImplementedException();

    public string RegistrationWaitingMessage => throw new NotImplementedException();

    public string ResetingPasswordWaitingMessage => throw new NotImplementedException();

    public string LoginCommonErrorTitle => throw new NotImplementedException();

    public string RegistrationCommonErrorTitle => throw new NotImplementedException();

    public string ResetingPasswordCommonErrorTitle => throw new NotImplementedException();

    public string AlertCancelButtonTitle => throw new NotImplementedException();
}