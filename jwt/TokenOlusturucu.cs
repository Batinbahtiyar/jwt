using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jwt
{
    public class TokenOlusturucu
    {
        public string TokenOlustur()
        {
            var bytes =Encoding.UTF8.GetBytes("batobatobato1");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
                notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30), signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();//bu clastan token oluşturulur
            return handler.WriteToken(token);
        }
        public string TokenAdminRoleOlustur()
        {
            var bytes = Encoding.UTF8.GetBytes("batobatobato1");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            List < Claim > claims= new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, "Admin"),/*Rol ekleme birden fazka eklemek için aynı işlem*/
            new Claim(ClaimTypes.Role,"Member"),
            new Claim(ClaimTypes.Name,"Batin"),
            new Claim("Sehir","Ankara")
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost",
                notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1), signingCredentials: credentials,claims:claims);
             /*İSSUER: bu tokunu sağlayan kişi yer */
            /*AUDİENCE: Bu tokunu kullanıcak kişi (bizi dinleyen kim)*/
            /*NOT BEFEORE : HANGİ TARİHTEN ÖNCE OLAMAZ (ŞUANDAN ONCE OLAMAZ)*/
            /*EXPİRESSE: ne kadar süre ayakta kalmak için */
            /*signingCredentials: imza bilgisi ilgili token çözmek için*/
            /* claims: Rol bazlı işlemleri yapmak için*/
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();/*bu clastan token oluşturulur*/
            return handler.WriteToken(jwtSecurityToken);/*security token alma kodu*/
        }
    }
}
