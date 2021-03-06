﻿using DellyShopApp.CommonData;
using DellyShopApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DellyShopApp.Services {
    public static class RestService {


        private static ObservableCollection<ChildWithProducts> childrenDetailList { get; set; }

        private static ObservableCollection<School> schoolsList { get; set; }

        private static ObservableCollection<School> childrenSchoolsList { get; set; }
        private static ParentProfile parentProfile { get; set; }

        private static UserInfo userInfoMobile { get; set; }
        private static ParentWithCrdandDeb parentCashInfo { get; set; }

        public static ObservableCollection<ChildWithProducts> GetChildrenMoneyAndProductsDetail(bool refresh = false) {

            if ( childrenDetailList == null || refresh ) {
                var url = $"{Global.WebApiUrl}/api/parent/GetChildrenMoneyAndProductsDetail?parentId={Global.ParentId}";
                var result = HelperClass.GetRecord( url );
                childrenDetailList = JsonConvert.DeserializeObject<ObservableCollection<ChildWithProducts>>( result );
            }

            return childrenDetailList;

        }

        public static ObservableCollection<School> GetSchoolsList(bool refresh = false) {

            if ( schoolsList == null || refresh ) {
                var url = $"{Global.WebApiUrl}/api/school/GetSchoolsSimpleList";
                var result = HelperClass.GetRecord( url );
                schoolsList = JsonConvert.DeserializeObject<ObservableCollection<School>>( result );
            }

            return schoolsList;

        }
        //https://pos2.dndaims.net/api/parent/GetParentTotalDebitCredit?id=55

        public static ParentWithCrdandDeb GetParentTotalDebitCredit(bool refresh = false) {

            if ( parentCashInfo == null || refresh ) {
                var url = $"{Global.WebApiUrl}/api/parent/GetParentTotalDebitCredit?id={Global.ParentId}";
                var result = HelperClass.GetRecord( url );
                parentCashInfo = JsonConvert.DeserializeObject<ParentWithCrdandDeb>( result );
            }

            return parentCashInfo;

        }
        ///
        /// 
        public static ObservableCollection<School> GetChildrenSchoolsList(bool refresh = false) {

            if ( childrenSchoolsList == null || refresh ) {
                var url = $"{Global.WebApiUrl}/api/school/GetSchoolsForAddMoney?parent_id={Global.ParentId}";
                var result = HelperClass.GetRecord( url );
                childrenSchoolsList = JsonConvert.DeserializeObject<ObservableCollection<School>>( result );
            }

            return childrenSchoolsList;

        }


        public static ParentProfile GetParentProfile(bool refresh = false) {
            if ( parentProfile == null || refresh )
                parentProfile = JsonConvert.DeserializeObject<ParentProfile>( HelperClass.GetRecord( string.Format( "{0}/api/parent/GetParentProfile?id={1}", Global.WebApiUrl, Global.ParentId ) ) );
            return parentProfile;
        }

        public static UserInfo GetUserInfoMobile(string email = null, bool refresh = false) {
            if ( userInfoMobile == null || refresh )
                userInfoMobile = JsonConvert.DeserializeObject<UserInfo>( HelperClass.GetRecord( Global.WebApiUrl + "/api/user/GetUserInfoMobile?username=" + ( email ?? Global.Username ) ) );
            return userInfoMobile;
        }

    }
}
