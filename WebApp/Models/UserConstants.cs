using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class UserConstants
    {
        public static IEnumerable<UserModel> users = new List<UserModel>
        {
            new UserModel{ Username = "rohith_admin", Password = "R_H_i_t_H", EmailAddress="rohithemail.gmail.com", Role="Admin", Surname="Govindalapudi", Givenname="RohithVinay"},
            new UserModel{ Username = "praharshin_seller", Password = "P_a_H_r_H_n_", EmailAddress="Praharshiniemail.gmail.com", Role="Seller", Surname="Tangella", Givenname="Praharshini"}
        };
    }
}
