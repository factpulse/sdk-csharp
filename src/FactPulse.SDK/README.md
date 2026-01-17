# Created with Openapi Generator

<a id="cli"></a>
## Creating the library
Create a config.yaml file similar to what is below, then run the following powershell command to generate the library `java -jar "<path>/openapi-generator/modules/openapi-generator-cli/target/openapi-generator-cli.jar" generate -c config.yaml`

```yaml
generatorName: csharp
inputSpec: /local/openapi.json
outputDir: out

# https://openapi-generator.tech/docs/generators/csharp
additionalProperties:
  packageGuid: '{ECFA28D2-92AC-4172-9643-0DAC081C3CF9}'

# https://openapi-generator.tech/docs/integrations/#github-integration
# gitHost:
# gitUserId:
# gitRepoId:

# https://openapi-generator.tech/docs/globals
# globalProperties:

# https://openapi-generator.tech/docs/customization/#inline-schema-naming
# inlineSchemaOptions:

# https://openapi-generator.tech/docs/customization/#name-mapping
# modelNameMappings:
# nameMappings:

# https://openapi-generator.tech/docs/customization/#openapi-normalizer
# openapiNormalizer:

# templateDir: https://openapi-generator.tech/docs/templating/#modifying-templates

# releaseNote:
```

<a id="usage"></a>
## Using the library in your project

```cs
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FactPulse.SDK.Api;
using FactPulse.SDK.Client;
using FactPulse.SDK.Model;
using Org.OpenAPITools.Extensions;

namespace YourProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var api = host.Services.GetRequiredService<IAFNORPDPPAApi>();
            IGetAfnorCredentialsApiV1AfnorCredentialsGetApiResponse apiResponse = await api.GetAfnorCredentialsApiV1AfnorCredentialsGetAsync("todo");
            Object? model = apiResponse.Ok();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
          .ConfigureApi((context, services, options) =>
          {
              // The type of token here depends on the api security specifications
              // Available token types are ApiKeyToken, BasicToken, BearerToken, HttpSigningToken, and OAuthToken.
              BearerToken token = new("<your token>");
              options.AddTokens(token);

              // optionally choose the method the tokens will be provided with, default is RateLimitProvider
              options.UseProvider<RateLimitProvider<BearerToken>, BearerToken>();

              options.ConfigureJsonOptions((jsonOptions) =>
              {
                  // your custom converters if any
              });

              options.AddApiHttpClients(client =>
              {
                  // client configuration
              }, builder =>
              {
                  builder
                      .AddRetryPolicy(2)
                      .AddTimeoutPolicy(TimeSpan.FromSeconds(5))
                      .AddCircuitBreakerPolicy(10, TimeSpan.FromSeconds(30));
                      // add whatever middleware you prefer
                  }
              );
          });
    }
}
```
<a id="questions"></a>
## Questions

- What about HttpRequest failures and retries?
  Configure Polly in the IHttpClientBuilder
- How are tokens used?
  Tokens are provided by a TokenProvider class. The default is RateLimitProvider which will perform client side rate limiting.
  Other providers can be used with the UseProvider method.
- Does an HttpRequest throw an error when the server response is not Ok?
  It depends how you made the request. If the return type is ApiResponse<T> no error will be thrown, though the Content property will be null.
  StatusCode and ReasonPhrase will contain information about the error.
  If the return type is T, then it will throw. If the return type is TOrDefault, it will return null.
- How do I validate requests and process responses?
  Use the provided On and After partial methods in the api classes.

## Api Information
- appName: FactPulse REST API
- appVersion: 1.0.0
- appDescription:  REST API for electronic invoicing in France: Factur-X, AFNOR PDP/PA, electronic signatures.  ## 🎯 Main Features  ### 📄 Factur-X Invoice Generation - **Formats**: XML only or PDF/A-3 with embedded XML - **Profiles**: MINIMUM, BASIC, EN16931, EXTENDED - **Standards**: EN 16931 (EU directive 2014/55), ISO 19005-3 (PDF/A-3), CII (UN/CEFACT) - **🆕 Simplified Format**: Generation from SIRET + auto-enrichment (Chorus Pro API + Business Search)  ### ✅ Validation and Compliance - **XML Validation**: Schematron (45 to 210+ rules depending on profile) - **PDF Validation**: PDF/A-3, Factur-X XMP metadata, electronic signatures - **VeraPDF**: Strict PDF/A validation (146+ ISO 19005-3 rules) - **Asynchronous Processing**: Celery support for heavy validations (VeraPDF)  ### 📡 AFNOR PDP/PA Integration (XP Z12-013) - **Flow Submission**: Send invoices to Partner Dematerialization Platforms - **Flow Search**: View submitted invoices - **Download**: Retrieve PDF/A-3 with XML - **Directory Service**: Company search (SIREN/SIRET) - **Multi-client**: Support for multiple PDP configs per user (stored credentials or zero-storage)  ### ✍️ PDF Electronic Signature - **Standards**: PAdES-B-B, PAdES-B-T (RFC 3161 timestamping), PAdES-B-LT (long-term archival) - **eIDAS Levels**: SES (self-signed), AdES (commercial CA), QES (QTSP) - **Validation**: Cryptographic integrity and certificate verification - **Certificate Generation**: Self-signed X.509 certificates for testing  ### 🔄 Asynchronous Processing - **Celery**: Asynchronous generation, validation and signing - **Polling**: Status tracking via &#x60;/tasks/{task_id}/status&#x60; - **No timeout**: Ideal for large files or heavy validations  ## 🔒 Authentication  All requests require a **JWT token** in the Authorization header: &#x60;&#x60;&#x60; Authorization: Bearer YOUR_JWT_TOKEN &#x60;&#x60;&#x60;  ### How to obtain a JWT token?  #### 🔑 Method 1: &#x60;/api/token/&#x60; API (Recommended)  **URL:** &#x60;https://factpulse.fr/api/token/&#x60;  This method is **recommended** for integration in your applications and CI/CD workflows.  **Prerequisites:** Having set a password on your account  **For users registered via email/password:** - You already have a password, use it directly  **For users registered via OAuth (Google/GitHub):** - You must first set a password at: https://factpulse.fr/accounts/password/set/ - Once the password is created, you can use the API  **Request example:** &#x60;&#x60;&#x60;bash curl -X POST https://factpulse.fr/api/token/ \\   -H \&quot;Content-Type: application/json\&quot; \\   -d &#39;{     \&quot;username\&quot;: \&quot;your_email@example.com\&quot;,     \&quot;password\&quot;: \&quot;your_password\&quot;   }&#39; &#x60;&#x60;&#x60;  **Optional &#x60;client_uid&#x60; parameter:**  To select credentials for a specific client (PA/PDP, Chorus Pro, signing certificates), add &#x60;client_uid&#x60;:  &#x60;&#x60;&#x60;bash curl -X POST https://factpulse.fr/api/token/ \\   -H \&quot;Content-Type: application/json\&quot; \\   -d &#39;{     \&quot;username\&quot;: \&quot;your_email@example.com\&quot;,     \&quot;password\&quot;: \&quot;your_password\&quot;,     \&quot;client_uid\&quot;: \&quot;550e8400-e29b-41d4-a716-446655440000\&quot;   }&#39; &#x60;&#x60;&#x60;  The &#x60;client_uid&#x60; will be included in the JWT and allow the API to automatically use: - AFNOR/PDP credentials configured for this client - Chorus Pro credentials configured for this client - Electronic signature certificates configured for this client  **Response:** &#x60;&#x60;&#x60;json {   \&quot;access\&quot;: \&quot;eyJ0eXAiOiJKV1QiLCJhbGc...\&quot;,  // Access token (validity: 30 min)   \&quot;refresh\&quot;: \&quot;eyJ0eXAiOiJKV1QiLCJhbGc...\&quot;  // Refresh token (validity: 7 days) } &#x60;&#x60;&#x60;  **Advantages:** - ✅ Full automation (CI/CD, scripts) - ✅ Programmatic token management - ✅ Refresh token support for automatic access renewal - ✅ Easy integration in any language/tool  #### 🖥️ Method 2: Dashboard Generation (Alternative)  **URL:** https://factpulse.fr/api/dashboard/  This method is suitable for quick tests or occasional use via the graphical interface.  **How it works:** - Log in to the dashboard - Use the \&quot;Generate Test Token\&quot; or \&quot;Generate Production Token\&quot; buttons - Works for **all** users (OAuth and email/password), without requiring a password  **Token types:** - **Test Token**: 24h validity, 1000 calls/day quota (free) - **Production Token**: 7 days validity, quota based on your plan  **Advantages:** - ✅ Quick for API testing - ✅ No password required - ✅ Simple visual interface  **Disadvantages:** - ❌ Requires manual action - ❌ No refresh token - ❌ Less suited for automation  ### 📚 Full Documentation  For more information on authentication and API usage: https://factpulse.fr/documentation-api/     

## Build
This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project.

- SDK version: 1.0.0
- Generator version: 7.19.0-SNAPSHOT
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
