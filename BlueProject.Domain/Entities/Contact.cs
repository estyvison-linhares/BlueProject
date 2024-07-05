using BlueProject.Domain.Exceptions;

namespace BlueProject.Domain.Entities
{
    public class Contact
    {
        private string _name;
        private string _email;
        private string _phone;

        public Contact(string? name, string? email, string? phone)
        {
            SetName(name);
            SetEmail(email);
            SetPhone(phone);
        }

        public int Id { get; private set; }

        public string Name => _name;
        public void SetName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidFieldException(nameof(Name), "Name cannot be empty");
            if (name.Length > 100)
                throw new InvalidFieldException(nameof(Name), name, "Name cannot exceed 100 characters");
            _name = name;
        }

        public string Email => _email;
        public void SetEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidFieldException(nameof(Email), "Email cannot be empty");
            if (!email.Contains("@"))
                throw new InvalidFieldException(nameof(Email), email, "Invalid email format");
            if (email.Length > 100)
                throw new InvalidFieldException(nameof(Email), email, "Email cannot exceed 100 characters");
            _email = email;
        }

        public string Phone => _phone;
        public void SetPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new InvalidFieldException(nameof(Phone), "Phone cannot be empty");
            if (phone.Length > 15)
                throw new InvalidFieldException(nameof(Phone), phone, "Phone cannot exceed 15 characters");
            _phone = phone;
        }
    }
}
