using DellyShopApp.CommonData;
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

    }
}
