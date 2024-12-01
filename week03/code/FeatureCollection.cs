public class FeatureCollection
{
    /// <summary>
    /// The type of the feature collection (e.g., "FeatureCollection").
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// A list of features, each representing an earthquake.
    /// </summary>
    public List<Feature> Features { get; set; }
}

public class Feature
{
    /// <summary>
    /// The type of the feature (e.g., "Feature").
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// The properties of the feature, including location and magnitude.
    /// </summary>
    public Properties Properties { get; set; }
}

public class Properties
{
    /// <summary>
    /// The location where the earthquake occurred.
    /// </summary>
    public string Place { get; set; }

    /// <summary>
    /// The magnitude of the earthquake.
    /// </summary>
    public double? Mag { get; set; }
}
