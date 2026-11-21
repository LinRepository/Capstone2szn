/* ============================================================================
   Seed_DefaultLandlord.sql   (NEW - Nov 21, 2026, first-run setup)
   Run ONCE on a fresh ApartmentDB, right after the schema script.

   Creates the default landlord account:
       Username : admin
       Password : hahahaha        (stored as a BCrypt hash, work factor 12)
       Role     : Landlord
       Name     : NULL            -> the app asks for the name on first use
                                     (FirstTimeNameForm, mandatory)

   On first login the app also forces the 3 security questions, and keeps
   showing the "default credentials" notice until BOTH the username and the
   password are changed (Settings > Profile Management).

   Keep the username/password in sync with FirstRunSetup.cs
   (DefaultLandlordUsername / DefaultLandlordPassword) and the user manual.
   ============================================================================ */
USE ApartmentDB;
GO

IF EXISTS (SELECT 1 FROM dbo.Users WHERE Role = 'Landlord')
BEGIN
    PRINT 'Skipped: a Landlord account already exists. Nothing was inserted.';
END
ELSE IF EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
BEGIN
    PRINT 'Skipped: the username "admin" is already taken. Nothing was inserted.';
END
ELSE
BEGIN
    INSERT INTO dbo.Users (Username, Password, Role, Name, EmployeeId)
    VALUES (N'admin',
            N'$2a$12$oy.2O0dIIOaxoyTpBiKS5ecrsocuPgghjizm.pfOejWonCQ4lFCAi',  -- BCrypt of "hahahaha"
            N'Landlord',
            NULL,      -- name is entered on first use
            NULL);     -- a Landlord has no employee record (CK_Users_RoleEmployee)

    PRINT 'Default landlord account created: admin / hahahaha';
END
GO

-- CHECK: expect 1 row, Name = NULL
SELECT UserId, Username, Role, Name, EmployeeId FROM dbo.Users WHERE Role = 'Landlord';
GO
