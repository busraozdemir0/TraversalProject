using System;

namespace TraversalProject.Areas.Admin.Models
{
    public class BookingHotelSearchViewModel
    {
        public int currentPage { get; set; }
        public Datum[] data { get; set; }
        public string message { get; set; }
        public int resultsPerPage { get; set; }
        public bool status { get; set; }
        public int totalPages { get; set; }
        public int totalResultCount { get; set; }

        public class Datum
        {
            public string __typename { get; set; }
            public bool acceptsWalletCredit { get; set; }
            public object[] badges { get; set; }
            public Basicpropertydata basicPropertyData { get; set; }
            public Block[] blocks { get; set; }
            public object[] bookerExperienceContentUIComponentProps { get; set; }
            public bool bundleRatesAvailable { get; set; }
            public Custombadges customBadges { get; set; }
            public object description { get; set; }
            public Displayname displayName { get; set; }
            public object geniusInfo { get; set; }
            public string idDetail { get; set; }
            public float inferredLocationScore { get; set; }
            public object isInCompanyBudget { get; set; }
            public bool isNewlyOpened { get; set; }
            public object licenseDetails { get; set; }
            public Location1 location { get; set; }
            public Matchingunitconfigurations matchingUnitConfigurations { get; set; }
            public Mealplanincluded mealPlanIncluded { get; set; }
            public int nbWishlists { get; set; }
            public Persuasion persuasion { get; set; }
            public Policies policies { get; set; }
            public Pricedisplayinfoirene priceDisplayInfoIrene { get; set; }
            public Propertysustainability propertySustainability { get; set; }
            public Recommendeddate recommendedDate { get; set; }
            public object recommendedDatesLabel { get; set; }
            public object relocationMode { get; set; }
            public Ribbon ribbon { get; set; }
            public object[] seoThemes { get; set; }
            public bool showAdLabel { get; set; }
            public bool showGeniusLoginMessage { get; set; }
            public bool showPrivateHostMessage { get; set; }
            public Soldoutinfo soldOutInfo { get; set; }
            public Trackonview[] trackOnView { get; set; }
            public bool? visibilityBoosterEnabled { get; set; }
        }

        public class Basicpropertydata
        {
            public string __typename { get; set; }
            public int accommodationTypeId { get; set; }
            public Alternativeexternalreviews alternativeExternalReviews { get; set; }
            public Externalreviews externalReviews { get; set; }
            public int id { get; set; }
            public bool isClosed { get; set; }
            public bool isTestProperty { get; set; }
            public Location location { get; set; }
            public string pageName { get; set; }
            public Paymentconfig paymentConfig { get; set; }
            public Photos photos { get; set; }
            public Reviews reviews { get; set; }
            public Starrating starRating { get; set; }
            public int ufi { get; set; }
        }

        public class Alternativeexternalreviews
        {
            public string __typename { get; set; }
            public int reviewsCount { get; set; }
            public bool showScore { get; set; }
           // public int totalScore { get; set; }
            public Totalscoretexttag totalScoreTextTag { get; set; }
        }

        public class Totalscoretexttag
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Externalreviews
        {
            public string __typename { get; set; }
            public int reviewsCount { get; set; }
            public bool showScore { get; set; }
            public int totalScore { get; set; }
            public Totalscoretexttag1 totalScoreTextTag { get; set; }
        }

        public class Totalscoretexttag1
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Location
        {
            public string __typename { get; set; }
            public string address { get; set; }
            public string city { get; set; }
            public string countryCode { get; set; }
        }

        public class Paymentconfig
        {
            public string __typename { get; set; }
            public object installments { get; set; }
        }

        public class Photos
        {
            public string __typename { get; set; }
            public Main main { get; set; }
        }

        public class Main
        {
            public string __typename { get; set; }
            public Highresjpegurl highResJpegUrl { get; set; }
            public Highresurl highResUrl { get; set; }
            public Lowresjpegurl lowResJpegUrl { get; set; }
            public Lowresurl lowResUrl { get; set; }
        }

        public class Highresjpegurl
        {
            public string __typename { get; set; }
            public string relativeUrl { get; set; }
        }

        public class Highresurl
        {
            public string __typename { get; set; }
            public string relativeUrl { get; set; }
        }

        public class Lowresjpegurl
        {
            public string __typename { get; set; }
            public string relativeUrl { get; set; }
        }

        public class Lowresurl
        {
            public string __typename { get; set; }
            public string relativeUrl { get; set; }
        }

        public class Reviews
        {
            public string __typename { get; set; }
            public int reviewsCount { get; set; }
            public float secondaryScore { get; set; }
            public Secondarytexttag secondaryTextTag { get; set; }
            public bool showScore { get; set; }
            public bool showSecondaryScore { get; set; }
            public float totalScore { get; set; }
            public Totalscoretexttag2 totalScoreTextTag { get; set; }
        }

        public class Secondarytexttag
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Totalscoretexttag2
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Starrating
        {
            public string __typename { get; set; }
            public Caption caption { get; set; }
            public bool showAdditionalInfoIcon { get; set; }
            public string symbol { get; set; }
            public Toclink tocLink { get; set; }
            public int value { get; set; }
        }

        public class Caption
        {
            public string __typename { get; set; }
            public object translation { get; set; }
        }

        public class Toclink
        {
            public string __typename { get; set; }
            public object translation { get; set; }
        }

        public class Custombadges
        {
            public string __typename { get; set; }
            public bool showBhTravelCreditBadge { get; set; }
            public bool showIsWorkFriendly { get; set; }
            public object showOnlineCheckinBadge { get; set; }
            public bool showParkAndFly { get; set; }
            public bool showSkiToDoor { get; set; }
        }

        public class Displayname
        {
            public string __typename { get; set; }
            public string text { get; set; }
            public Translationtag translationTag { get; set; }
        }

        public class Translationtag
        {
            public string __typename { get; set; }
            public object translation { get; set; }
        }

        public class Location1
        {
            public string __typename { get; set; }
            public string beachDistance { get; set; }
            public object beachWalkingTime { get; set; }
            public string displayLocation { get; set; }
            public object geoDistanceMeters { get; set; }
            public string mainDistance { get; set; }
            public string[] nearbyBeachNames { get; set; }
            public object publicTransportDistanceDescription { get; set; }
            public object skiLiftDistance { get; set; }
        }

        public class Matchingunitconfigurations
        {
            public string __typename { get; set; }
            public Commonconfiguration commonConfiguration { get; set; }
            public Unitconfiguration[] unitConfigurations { get; set; }
        }

        public class Commonconfiguration
        {
            public string __typename { get; set; }
            public Bedconfiguration[] bedConfigurations { get; set; }
            public Localizedarea localizedArea { get; set; }
            public object name { get; set; }
            public int nbAllBeds { get; set; }
            public int nbBathrooms { get; set; }
            public int nbBedrooms { get; set; }
            public int nbKitchens { get; set; }
            public int nbLivingrooms { get; set; }
            public int nbPools { get; set; }
            public int nbUnits { get; set; }
            public int unitId { get; set; }
            public Unittypename[] unitTypeNames { get; set; }
        }

        public class Localizedarea
        {
            public string __typename { get; set; }
            public string localizedArea { get; set; }
            public string unit { get; set; }
        }

        public class Bedconfiguration
        {
            public string __typename { get; set; }
            public Bed[] beds { get; set; }
            public int nbAllBeds { get; set; }
        }

        public class Bed
        {
            public string __typename { get; set; }
            public int count { get; set; }
            public int type { get; set; }
        }

        public class Unittypename
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Unitconfiguration
        {
            public string __typename { get; set; }
            public Apartmentroom[] apartmentRooms { get; set; }
            public Bedconfiguration1[] bedConfigurations { get; set; }
            public Localizedarea1 localizedArea { get; set; }
            public string name { get; set; }
            public int nbAllBeds { get; set; }
            public int nbBathrooms { get; set; }
            public int nbBedrooms { get; set; }
            public int nbKitchens { get; set; }
            public int nbLivingrooms { get; set; }
            public int nbPools { get; set; }
            public int nbUnits { get; set; }
            public int unitId { get; set; }
            public Unittypename1[] unitTypeNames { get; set; }
        }

        public class Localizedarea1
        {
            public string __typename { get; set; }
            public string localizedArea { get; set; }
            public string unit { get; set; }
        }

        public class Apartmentroom
        {
            public string __typename { get; set; }
            public Config config { get; set; }
            public Tag tag { get; set; }
        }

        public class Config
        {
            public string __typename { get; set; }
            public int bedTypeId { get; set; }
            public int count { get; set; }
            public int id { get; set; }
            public string roomType { get; set; }
        }

        public class Tag
        {
            public string __typename { get; set; }
            public string tag { get; set; }
            public string translation { get; set; }
        }

        public class Bedconfiguration1
        {
            public string __typename { get; set; }
            public Bed1[] beds { get; set; }
            public int nbAllBeds { get; set; }
        }

        public class Bed1
        {
            public string __typename { get; set; }
            public int count { get; set; }
            public int type { get; set; }
        }

        public class Unittypename1
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Mealplanincluded
        {
            public string __typename { get; set; }
            public string mealPlanType { get; set; }
            public string text { get; set; }
        }

        public class Persuasion
        {
            public string __typename { get; set; }
            public bool autoextended { get; set; }
            public object bookedXTimesMessage { get; set; }
            public bool geniusRateAvailable { get; set; }
            public bool highlighted { get; set; }
            public object nativeAdId { get; set; }
            public object nativeAdsCpc { get; set; }
            public object nativeAdsTracking { get; set; }
            public bool preferred { get; set; }
            public bool preferredPlus { get; set; }
            public bool showNativeAdLabel { get; set; }
            public object sponsoredAdsData { get; set; }
        }

        public class Policies
        {
            public string __typename { get; set; }
            public object enableJapaneseUsersSpecialCase { get; set; }
            public bool showFreeCancellation { get; set; }
            public bool showNoPrepayment { get; set; }
        }

        public class Pricedisplayinfoirene
        {
            public string __typename { get; set; }
            public Badge[] badges { get; set; }
            public Chargesinfo chargesInfo { get; set; }
            public Discount[] discounts { get; set; }
            public Displayprice displayPrice { get; set; }
            public Excludedcharges excludedCharges { get; set; }
            public Pricebeforediscount priceBeforeDiscount { get; set; }
            public Rewards rewards { get; set; }
            public object[] taxExceptions { get; set; }
            public bool useRoundedAmount { get; set; }
        }

        public class Chargesinfo
        {
            public string __typename { get; set; }
            public object translation { get; set; }
        }

        public class Displayprice
        {
            public string __typename { get; set; }
            public Amountperstay amountPerStay { get; set; }
            public Copy copy { get; set; }
        }

        public class Amountperstay
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public float amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Copy
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Excludedcharges
        {
            public string __typename { get; set; }
            public Excludechargesaggregated excludeChargesAggregated { get; set; }
            public Excludechargeslist[] excludeChargesList { get; set; }
        }

        public class Excludechargesaggregated
        {
            public string __typename { get; set; }
            public Amountperstay1 amountPerStay { get; set; }
            public Copy1 copy { get; set; }
        }

        public class Amountperstay1
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public float amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Copy1
        {
            public string __typename { get; set; }
            public object translation { get; set; }
        }

        public class Excludechargeslist
        {
            public string __typename { get; set; }
            public Amountperstay2 amountPerStay { get; set; }
            public string chargeInclusion { get; set; }
            public string chargeMode { get; set; }
            public int chargeType { get; set; }
        }

        public class Amountperstay2
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public float amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Pricebeforediscount
        {
            public string __typename { get; set; }
            public Amountperstay3 amountPerStay { get; set; }
            public Copy2 copy { get; set; }
        }

        public class Amountperstay3
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public float amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Copy2
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Rewards
        {
            public string __typename { get; set; }
            public Rewardsaggregated rewardsAggregated { get; set; }
            public object[] rewardsList { get; set; }
        }

        public class Rewardsaggregated
        {
            public string __typename { get; set; }
            public Amountperstay4 amountPerStay { get; set; }
            public Copy3 copy { get; set; }
        }

        public class Amountperstay4
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public int amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Copy3
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Badge
        {
            public string __typename { get; set; }
            public string identifier { get; set; }
            public Name name { get; set; }
            public string style { get; set; }
            public Tooltip tooltip { get; set; }
        }

        public class Name
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Tooltip
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Discount
        {
            public string __typename { get; set; }
            public Amount amount { get; set; }
            public Description description { get; set; }
            public string itemType { get; set; }
            public Name1 name { get; set; }
            public string productId { get; set; }
        }

        public class Amount
        {
            public string __typename { get; set; }
            public string amount { get; set; }
            public string amountRounded { get; set; }
            public float amountUnformatted { get; set; }
            public string currency { get; set; }
        }

        public class Description
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Name1
        {
            public string __typename { get; set; }
            public string translation { get; set; }
        }

        public class Propertysustainability
        {
            public string __typename { get; set; }
            public Certification[] certifications { get; set; }
            public object chainProgrammes { get; set; }
            public Facility[] facilities { get; set; }
            public bool isSustainable { get; set; }
            public string levelId { get; set; }
            public Tier tier { get; set; }
        }

        public class Tier
        {
            public string __typename { get; set; }
            public string type { get; set; }
        }

        public class Certification
        {
            public string __typename { get; set; }
            public string name { get; set; }
        }

        public class Facility
        {
            public string __ref { get; set; }
        }

        public class Recommendeddate
        {
            public string __typename { get; set; }
            public string checkin { get; set; }
            public string checkout { get; set; }
            public int lengthOfStay { get; set; }
        }

        public class Ribbon
        {
            public string __typename { get; set; }
            public string ribbonType { get; set; }
            public string text { get; set; }
        }

        public class Soldoutinfo
        {
            public string __typename { get; set; }
            public object[] alternativeDatesMessages { get; set; }
            public bool isSoldOut { get; set; }
            public object[] messages { get; set; }
        }

        public class Block
        {
            public string __typename { get; set; }
            public Blockid blockId { get; set; }
            public Blockmatchtags blockMatchTags { get; set; }
            public Finalprice finalPrice { get; set; }
            public DateTime? freeCancellationUntil { get; set; }
            public bool hasCrib { get; set; }
            public Onlyxleftmessage onlyXLeftMessage { get; set; }
            public Originalprice originalPrice { get; set; }
            public Thirdpartyinventorycontext thirdPartyInventoryContext { get; set; }
        }

        public class Blockid
        {
            public string __typename { get; set; }
            public int mealPlanId { get; set; }
            public int occupancy { get; set; }
            public string packageId { get; set; }
            public string policyGroupId { get; set; }
            public string roomId { get; set; }
        }

        public class Blockmatchtags
        {
            public string __typename { get; set; }
            public bool childStaysForFree { get; set; }
        }

        public class Finalprice
        {
            public string __typename { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Onlyxleftmessage
        {
            public string __typename { get; set; }
            public object tag { get; set; }
            public string translation { get; set; }
            public object[] variables { get; set; }
        }

        public class Originalprice
        {
            public string __typename { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Thirdpartyinventorycontext
        {
            public string __typename { get; set; }
            public bool isTpiBlock { get; set; }
        }

        public class Trackonview
        {
            public string __typename { get; set; }
            public string experimentTag { get; set; }
        }
    }

}
