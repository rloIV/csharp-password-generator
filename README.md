# Password Generator Program V2

## Overview
This is a simple console-based password generator program written in C#. It allows users to generate secure passwords with customizable settings and assess their strength based on length and character variety.

## Features
- **Customizable Settings**:
  - Set password length (1-64 characters).
  - Include or exclude uppercase letters, lowercase letters, numbers, and special characters.
- **Password Strength Assessment**:
  - The program evaluates the strength of the generated password as `Weak`, `Medium`, or `Strong` based on length and character variety.
- **User-Friendly Menu**:
  - Intuitive options to configure settings, generate passwords, and view strength assessments.

## How It Works
1. Launch the program in a console environment.
2. Configure the password settings:
   - Change the password length.
   - Include/exclude different character types.
3. Generate a password and view its strength.

## Menu Options
1. **Change Password Length**
   - Allows the user to specify the desired length of the password (1-64 characters).
2. **Configure Password Components**
   - Enables users to toggle the inclusion of uppercase letters, lowercase letters, numbers, and special characters.
3. **Generate Password and Check Strength**
   - Generates a random password based on the configured settings.
   - Displays the generated password and its strength (`Weak`, `Medium`, or `Strong`).
4. **Exit**
   - Exits the program.

## Password Strength Assessment
The program evaluates password strength using the following criteria:
- **Weak**: Length < 8 or minimal character variety.
- **Medium**: Length >= 8 with moderate character variety.
- **Strong**: Length >= 12 with a diverse mix of uppercase, lowercase, numbers, and special characters.

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/rloIV/password-generator.git
   ```
2. Navigate to the project directory:
   ```bash
   cd password-generator
   ```
3. Open the project in your preferred C# IDE (e.g., Visual Studio).
4. Build and run the project.

## Example
```
Password Generator Program V3
Current Settings:
- Password Length: 12
- Include Uppercase Letters: Yes
- Include Lowercase Letters: Yes
- Include Numbers: Yes
- Include Special Characters: No

Menu:
1. Change password length
2. Configure password components
3. Generate password and check strength
4. Exit

Your choice: 3

Generating password...
Generated Password: Abc123xyz
Password Strength: Medium
```

## License
This project is licensed under the MIT License. See the LICENSE file for more details.

Cheers!
