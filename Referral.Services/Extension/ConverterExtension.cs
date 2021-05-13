//using Referral.Models;

//namespace Referral.Services.Extension
//{
//    public static class ConverterExtension
//    {
//        public static CustomerModal ConvertModel(this DAL.Models.CustomerModal model)
//        {
//            if (model != null)
//            {
//                return new CustomerModal()
//                {
//                    CustomerModalFirstName = model.CustomerModalFirstName,
//                    CustomerModalLastName = model.CustomerModalLastName,
//                    CustomerModalArea = model.CustomerModalArea,
//                    CustomerModalPhoneNumber = model.CustomerModalPhoneNumber
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.CustomerModal ConvertModel(this CustomerModal model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.CustomerModal()
//                {
//                    CustomerModalFirstName = model.CustomerModalFirstName,
//                    CustomerModalLastName = model.CustomerModalLastName,
//                    CustomerModalArea = model.CustomerModalArea,
//                    CustomerModalPhoneNumber = model.CustomerModalPhoneNumber
//                };
//            }

//            return null;
//        }

//        public static Customers ConvertModel(this DAL.Models.Customers model)
//        {
//            if (model != null)
//            {
//                return new Customers()
//                {
//                    Id=model.Id,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    Address = model.Address,
//                    Area = model.Area,
//                    Dob = model.Dob,
//                    City = model.City,
//                    IsActive = model.IsActive,
//                    IsDeleted = model.IsDeleted,
//                    ReferralId = model.ReferralId,
//                    Email = model.Email,
//                    PhoneNumber = model.PhoneNumber,
//                    EmailConfirmed = model.EmailConfirmed,
//                    PhoneNumberConfirmed = model.PhoneNumberConfirmed,
//                    UserName = model.UserName,
//                    PasswordHash = model.PasswordHash
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.Customers ConvertModel(this Customers model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.Customers()
//                {
//                    Id = model.Id,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    Address = model.Address,
//                    Area = model.Area,
//                    Dob = model.Dob,
//                    City = model.City,
//                    IsActive = model.IsActive,
//                    IsDeleted = model.IsDeleted,
//                    ReferralId = model.ReferralId,
//                    Email = model.Email,
//                    PhoneNumber = model.PhoneNumber,
//                    EmailConfirmed = model.EmailConfirmed,
//                    PhoneNumberConfirmed = model.PhoneNumberConfirmed,
//                    UserName = model.UserName,
//                    PasswordHash = model.PasswordHash
//                };
//            }

//            return null;
//        }

//        public static CustomersPoints ConvertModel(this DAL.Models.CustomersPoints model)
//        {
//            if (model != null)
//            {
//                return new CustomersPoints()
//                {
//                    Id = model.Id,
//                    CustomerId = model.CustomerId,
//                    PointType = (PointType)model.PointType,
//                    PointEarned = model.PointEarned,
//                    CreateDate = model.CreateDate
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.CustomersPoints ConvertModel(this CustomersPoints model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.CustomersPoints()
//                {
//                    Id = model.Id,
//                    CustomerId = model.CustomerId,
//                    PointType = (DAL.Models.PointType)model.PointType,
//                    PointEarned = model.PointEarned,
//                    CreateDate = model.CreateDate
//                };
//            }

//            return null;
//        }

//        public static CustomersPurchase ConvertModel(this DAL.Models.CustomersPurchase model)
//        {
//            if (model != null)
//            {
//                return new CustomersPurchase()
//                {
//                    Id = model.Id,
//                    CustomerId = model.CustomerId,
//                    Amount = model.Amount,
//                    PurchaseDate = model.PurchaseDate
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.CustomersPurchase ConvertModel(this CustomersPurchase model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.CustomersPurchase()
//                {
//                    Id = model.Id,
//                    CustomerId = model.CustomerId,
//                    Amount = model.Amount,
//                    PurchaseDate = model.PurchaseDate
//                };
//            }

//            return null;
//        }

//        public static Operators ConvertModel(this DAL.Models.Operators model)
//        {
//            if (model != null)
//            {
//                return new Operators()
//                {
//                    Id = model.Id,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    Address = model.Address,
//                    Area = model.Area,
//                    Dob = model.Dob,
//                    City = model.City,
//                    IsActive = model.IsActive,
//                    IsDeleted = model.IsDeleted,
//                    ReferralId = model.ReferralId,
//                    Email = model.Email,
//                    PhoneNumber = model.PhoneNumber,
//                    EmailConfirmed = model.EmailConfirmed,
//                    PhoneNumberConfirmed = model.PhoneNumberConfirmed,
//                    UserName = model.UserName,
//                    PasswordHash = model.PasswordHash
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.Operators ConvertModel(this Operators model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.Operators()
//                {
//                    Id = model.Id,
//                    FirstName = model.FirstName,
//                    LastName = model.LastName,
//                    Address = model.Address,
//                    Area = model.Area,
//                    Dob = model.Dob,
//                    City = model.City,
//                    IsActive = model.IsActive,
//                    IsDeleted = model.IsDeleted,
//                    ReferralId = model.ReferralId,
//                    Email = model.Email,
//                    PhoneNumber = model.PhoneNumber,
//                    EmailConfirmed = model.EmailConfirmed,
//                    PhoneNumberConfirmed = model.PhoneNumberConfirmed,
//                    UserName = model.UserName,
//                    PasswordHash = model.PasswordHash
//                };
//            }

//            return null;
//        }

//        public static RedeemPoints ConvertModel(this DAL.Models.RedeemPoints model)
//        {
//            if (model != null)
//            {
//                return new RedeemPoints()
//                {
//                    TotalPoint = model.TotalPoint,
//                    CustomerId = model.CustomerId,
//                    MaxRedeemPoint = model.MaxRedeemPoint,
//                    RedeemAmount = model.RedeemAmount
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.RedeemPoints ConvertModel(this RedeemPoints model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.RedeemPoints()
//                {
//                    TotalPoint = model.TotalPoint,
//                    CustomerId = model.CustomerId,
//                    MaxRedeemPoint = model.MaxRedeemPoint,
//                    RedeemAmount = model.RedeemAmount
//                };
//            }

//            return null;
//        }

//        public static ReferralConfig ConvertModel(this DAL.Models.ReferralConfig model)
//        {
//            if (model != null)
//            {
//                return new ReferralConfig()
//                {
//                    Id = model.Id,
//                    FMP = model.FMP,
//                    //PPA = model.PPA,
//                    RedeemPointPercentage = model.RedeemPointPercentage,
//                    ReferralPoints = model.ReferralPoints,
//                    RedeemPointValue = model.RedeemPointValue,
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.ReferralConfig ConvertModel(this ReferralConfig model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.ReferralConfig()
//                {
//                    Id = model.Id,
//                    FMP = model.FMP,
//                    //PPA = model.PPA,
//                    RedeemPointPercentage = model.RedeemPointPercentage,
//                    ReferralPoints = model.ReferralPoints,
//                    RedeemPointValue = model.RedeemPointValue,
//                };
//            }

//            return null;
//        }


//        public static PointPurchaseAmount ConvertModel(this DAL.Models.PointPurchaseAmount model)
//        {
//            if (model != null)
//            {
//                return new PointPurchaseAmount()
//                {
//                    Id = model.Id,
//                    Points = model.Points,
//                    //PPA = model.PPA,
//                    PurchaseAmount = model.PurchaseAmount,
//                };
//            }

//            return null;
//        }

//        public static DAL.Models.PointPurchaseAmount ConvertModel(this PointPurchaseAmount model)
//        {
//            if (model != null)
//            {
//                return new DAL.Models.PointPurchaseAmount()
//                {
//                    Id = model.Id,
//                    Points = model.Points,
//                    //PPA = model.PPA,
//                    PurchaseAmount = model.PurchaseAmount,
//                };
//            }

//            return null;
//        }
//    }
//}
