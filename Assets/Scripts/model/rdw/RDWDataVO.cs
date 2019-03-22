namespace Ordina.Model.RDW {

    [System.Serializable]
    public struct VoertuigSpecificatieVO {
        public string aantal_cilinders;
        public string aantal_deuren;
        public string aantal_rolstoelplaatsen;
        public string aantal_wielen;
        public string aantal_zitplaatsen;
        public string afstand_hart_koppeling_tot_achterzijde_voertuig;
        public string afstand_voorzijde_voertuig_tot_hart_koppeling;
        public string api_gekentekende_voertuigen_assen;
        public string api_gekentekende_voertuigen_brandstof;
        public string api_gekentekende_voertuigen_carrosserie;
        public string api_gekentekende_voertuigen_carrosserie_specifiek;
        public string api_gekentekende_voertuigen_voertuigklasse;
        public string breedte;
        public string catalogusprijs;
        public string cilinderinhoud;
        public string datum_eerste_afgifte_nederland;
        public string datum_eerste_toelating;
        public string datum_tenaamstelling;
        public string eerste_kleur;
        public string europese_voertuigcategorie;
        public string export_indicator;
        public string handelsbenaming;
        public string inrichting;
        public string kenteken;
        public string lengte;
        public string massa_ledig_voertuig;
        public string massa_rijklaar;
        public string maximum_massa_samenstelling;
        public string merk;
        public string openstaande_terugroepactie_indicator;
        public string plaats_chassisnummer;
        public string taxi_indicator;
        public string technische_max_massa_voertuig;
        public string toegestane_maximum_massa_voertuig;
        public string tweede_kleur;
        public string type;
        public string typegoedkeuringsnummer;
        public string uitvoering;
        public string variant;
        public string vermogen_massarijklaar;
        public string vervaldatum_apk;
        public string voertuigsoort;
        public string volgnummer_wijziging_eu_typegoedkeuring;
        public string wacht_op_keuren;
        public string wam_verzekerd;
        public string wielbasis;
        public string zuinigheidslabel;
    }

    [System.Serializable]
    public struct APK_KeuringVO {
        public string aantal_gebreken_geconstateerd;
        public string gebrek_identificatie;
        public string kenteken;
        public string meld_datum_door_keuringsinstantie;
        public string meld_tijd_door_keuringsinstantie;
        public string soort_erkenning_keuringsinstantie;
        public string soort_erkenning_omschrijving;
    }
}
