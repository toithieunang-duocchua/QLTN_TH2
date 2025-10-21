# QLTN Desktop Application

## Setup And Run
1. **Create database:** Execute `qltn_main.sql` inside SQL Server Management Studio to provision the `qltn` database (or `qltn2` if you prefer a separate test copy).
2. **Seed admin account (optional):**
   ```sql
   INSERT INTO nguoidung (tenDangNhap, matKhau, hoTen, email, soDienThoai, vaiTro, trangThai, ngayTao, ngayCapNhat)
   VALUES ('admin', 'Admin@123', 'Admin User', 'admin@example.com', '0708624193', 'Admin', 1, GETDATE(), GETDATE());
   ```
3. **Build:** Open `QLTN.sln` with Visual Studio 2019+ and run the WinForms project.

## Demo Account
- Phone: `0708624193`
- Password: `Admin@123`
- Verification code (static only for demo): `123456`

## n8n-Managed Verification Codes (Preferred)
1. **Create two webhooks (they can live in the same workflow):**
   - **`/webhook/request-verification`**  
     Input JSON: `{ "email": "user@example.com", "requestedAtUtc": "..." }`  
     Steps: generate a 6-digit code, store it with a 5-minute expiry (Data Store node, Redis, MySQL, etc.), and send the email (Gmail node).  
     Respond with JSON:
     ```json
     {
       "success": true,
       "expiresAtUtc": "2025-10-21T04:12:00Z",
       "message": "Verification code sent"
     }
     ```
   - **`/webhook/verify-code`**  
     Input JSON: `{ "email": "user@example.com", "code": "123456", "verifiedAtUtc": "..." }`  
     Steps: look up the stored code, validate expiry/matching, then respond with JSON:
     ```json
     {
       "status": "success",              // or expired / incorrect / not_requested
       "message": "Code validated",
       "remainingSeconds": 180
     }
     ```
2. **Add authentication (optional):** In Webhook settings enable header auth. Set the header name to `X-N8N-API-KEY` (or your own) and supply the same value in `App.config` (`N8nApiKeyHeader`, `N8nApiKey`). Leave them blank if you do not need authentication.
3. **Update `App.config`:**
   ```xml
   <add key="N8nBaseUrl" value="https://terrykozte.app.n8n.cloud/" />
   <add key="N8nRequestVerificationPath" value="webhook/request-verification" />
   <add key="N8nVerifyCodePath" value="webhook/verify-code" />
   ```
   When both paths are present, `EmailVerificationService` delegates code generation and verification entirely to n8n.
4. **Test the flow:** In the app choose “Forgot password”, enter a registered email, then type the code you receive. The request webhook sends the email and the verify webhook confirms the code before allowing the password reset screen.

## Gmail API Fallback (n8n disabled)
If you leave the n8n keys empty the application falls back to the built-in Gmail sender:
1. **Enable Gmail API:** In Google Cloud Console create a Desktop OAuth client.
2. **Consent scope:** include `https://www.googleapis.com/auth/gmail.send`.
3. **Refresh token:** obtain it through OAuth Playground (or custom tooling) and store it securely.
4. **Update `App.config`:** fill `GoogleClientId`, `GoogleClientSecret`, `GoogleRefreshToken`, `GoogleSenderEmail`, `GoogleSenderName`.
5. **Run "Forgot password":** the WinForms app generates/stores codes locally for five minutes and sends them by calling Gmail’s REST API directly.

## Application Configuration Checklist
- `App.config` (and the sample `App.config.example`) holds all secrets for Google OAuth and n8n.
- Do not commit real client secrets, refresh tokens, or n8n API keys to source control.
- The verification flow: Login form -> Forgot password -> Verification code (email + timer) -> Reset password -> Back to login.
- All API-related code lives under the `API` folder to keep WinForms UI code clean.
