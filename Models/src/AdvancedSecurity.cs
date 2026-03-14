namespace SnDOne.Models;

// Partial class
public partial class SnDOne {
    /// <summary>
    /// Advanced Security class
    /// </summary>
    public class AdvancedSecurity : AdvancedSecurityBase
    {
        // Constructor
        public AdvancedSecurity() : base()
        {
            Security = this;
        }

        // User Custom Validate event
        public override bool UserCustomValidate(ref string usr, ref string pwd) {
            // Enter your custom code to validate user, return true if valid.
            if (Session.GetBool("BypassIdamanPwdCheck"))
            {
                Session.SetBool("BypassIdamanPwdCheck", false);
                return true;
            }
            return false;
        }
    }
} // End Partial class
