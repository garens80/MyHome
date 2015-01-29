﻿using System.Collections.Generic;
using DataAccess;
using LocalTypes;
using System.Linq;

namespace BusinessLogic
{
    /// <summary>
    /// Holds methods for sorting and making calculations on the data of payment methods
    /// Is also the bridge from the UI to the Dal
    /// </summary>
    public class PaymentMethodHandler : BaseCategoryHandler
    {//TODO should the handler methods simply have a property of the appropiate access class?
        #region CRUD Methods

        #region Read Methods

        /// <summary>
        /// Loads a specific Payment Method from the cache
        /// </summary>
        /// <param name="id">The id of the Payment Method wanted</param>
        /// <returns>The Payment Method as it is in the cache</returns>
        public static PaymentMethod LoadById(int id)
        {
            var r = new CachedPaymentMethodRepository(new PaymentMethodAccess(ConnectionManager.ProviderFactory));
            return r.LoadById(id);
        }

        /// <summary>
        /// Loads all the Payment Methods from the cache
        /// </summary>
        /// <returns>All the Payment Methods as they are in the cache in generic-based
        /// list
        /// </returns>
        public override List<BaseCategory> LoadAll()
        {
            var r = new CachedPaymentMethodRepository(new PaymentMethodAccess(ConnectionManager.ProviderFactory));
            return r.LoadAll().ToList<BaseCategory>();
        }

        #endregion

        #region Create Methods

        public override int AddNewCategory(string categoryName)
        {
            var r = new CachedPaymentMethodRepository(new PaymentMethodAccess(ConnectionManager.ProviderFactory));
            var result = r.Save(new PaymentMethod { Name = categoryName });
            return result != null ? result.Id : 0;
        }

        #endregion

        #region Update Methods

        public override bool Save(BaseCategory categoryToSave)
        {
            var r = new CachedPaymentMethodRepository(new PaymentMethodAccess(ConnectionManager.ProviderFactory));
            var result = r.Save(categoryToSave as PaymentMethod);
            return result != null;
        }

        #endregion

        #endregion

    }
}
