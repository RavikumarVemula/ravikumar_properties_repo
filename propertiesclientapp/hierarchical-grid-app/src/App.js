import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './HierarchicalGrid.css';

const HierarchicalGrid = () => {
  const [properties, setProperties] = useState([]); // State to store the fetched data
  const [loading, setLoading] = useState(true); // Loading state to display loading indicator

  // Fetch data from the API when the component mounts
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7120/api/properties"); // Replace with your API endpoint
        setProperties(response.data); // Set the fetched data into state
        console.info(response.data);
      } catch (error) {
        console.error("Error fetching data:", error);
      } finally {
        setLoading(false); // Set loading to false once data is fetched or error occurs
      }
    };

    fetchData(); // Call the fetchData function on component mount
  }, []); // Empty array ensures this runs once on mount

  // Render the component UI
  return (
    <div className="hierarchical-grid">
      <h2>Property Hierarchical Grid</h2>
      {loading ? (
        <p>Loading data...</p> // Display loading message if data is being fetched
      ) : properties.length > 0 ? (
        <PropertyGrid properties={properties} /> // Pass all properties to PropertyGrid
      ) : (
        <p>No data available.</p> // Display if no properties are available
      )}
    </div>
  );
};

// Render individual property card with nested spaces and rent roll
const PropertyGrid = ({ properties }) => {
  if (!properties || properties.length === 0) {
    return <div>No properties available.</div>;
  }

  return (
    <div className="grid-container">
      {properties.map((property, propertyIndex) => (
        <div key={`property-${property.PropertyId || propertyIndex}`} className="property">
          <h2>{property.PropertyName}</h2>

          {/* Features */}
          <div className="features">
            <h3>Features:</h3>
            <ul>
              {property.Features?.map((feature, featureIndex) => (
                <li key={`feature-${property.PropertyId}-${featureIndex}`}>{feature}</li>
              ))}
            </ul>
          </div>

          {/* Highlights */}
          <div className="highlights">
            <h3>Highlights:</h3>
            <ul>
              {property.Highlights?.map((highlight, highlightIndex) => (
                <li key={`highlight-${property.PropertyId}-${highlightIndex}`}>{highlight}</li>
              ))}
            </ul>
          </div>

          {/* Transportation */}
          <div className="transportation">
            <h3>Transportation:</h3>
            <ul>
              {property.Transportation?.map((transport, transportIndex) => (
                <li key={`transport-${property.PropertyId}-${transportIndex}`}>
                  {transport.Type} - {transport.Line || transport.Station} ({transport.Distance})
                </li>
              ))}
            </ul>
          </div>

          {/* Spaces */}
          <div className="spaces">
            <h3>Spaces:</h3>
            {property.Spaces?.map((space, spaceIndex) => (
              <div key={`space-${property.PropertyId}-${space.SpaceId || spaceIndex}`} className="space">
                <h4>{space.SpaceName}</h4>
                <table>
                  <thead>
                    <tr>
                      <th>Month</th>
                      <th>Rent</th>
                    </tr>
                  </thead>
                  <tbody>
                    {space.RentRoll?.map((rent, rentIndex) => (
                      <tr key={`rent-${property.PropertyId}-${space.SpaceId || spaceIndex}-${rentIndex}`}>
                        <td>{rent.Month}</td>
                        <td>${rent.Rent}</td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};

export default HierarchicalGrid;
