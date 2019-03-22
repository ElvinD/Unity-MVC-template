using System.Collections.Generic;

namespace Ordina.Model.RDW {

    [System.Serializable]
    public struct ProcessingTime {
        public double total;
        public double plates;
        public double vehicles;
    }

    [System.Serializable]
    public struct VehicleRegion {
        public int y;
        public int x;
        public int height;
        public int width;
    }

    [System.Serializable]
    public struct Candidate {
        public int matches_template;
        public string plate;
        public double confidence;
    }

    [System.Serializable]
    public struct Coordinate {
        public int y;
        public int x;
    }

    [System.Serializable]
    public struct Orientation {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct Color {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct Make {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct BodyType {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct Year {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct MakeModel {
        public double confidence;
        public string name;
    }

    [System.Serializable]
    public struct Vehicle {
        public List<Orientation> orientation;
        public List<Color> color;
        public List<Make> make;
        public List<BodyType> body_type;
        public List<Year> year;
        public List<MakeModel> make_model;
    }

    [System.Serializable]
    public struct Result {
        public string plate;
        public double confidence;
        public int region_confidence;
        public VehicleRegion vehicle_region;
        public string region;
        public int plate_index;
        public double processing_time_ms;
        public List<Candidate> candidates;
        public List<Coordinate> coordinates;
        public Vehicle vehicle;
        public int matches_template;
        public int requested_topn;
    }

    [System.Serializable]
    public struct RegionsOfInterest {
        public int y;
        public int x;
        public int height;
        public int width;
    }

    [System.Serializable]
    public struct OpenALPRVO {
        public string uuid;
        public string data_type;
        public long epoch_time;
        public ProcessingTime processing_time;
        public int img_height;
        public int img_width;
        public List<Result> results;
        public int credits_monthly_used;
        public int version;
        public int credits_monthly_total;
        public bool error;
        public List<RegionsOfInterest> regions_of_interest;
        public int credit_cost;
    }
}