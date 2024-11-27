import React, { useEffect, useState } from 'react';
import axios from 'axios';
import CollapsibleSection from './HierarchicalGrid.jsx'; // Import the component

const PropertyList = () => {
  const [properties, setProperties] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get('https://localhost:7120/api/properties')
      .then(response => {
        setProperties(response.data);
        setLoading(false);
      })
      .catch(error => {
        console.error("There was an error fetching the properties!", error);
        setLoading(false);
      });
  }, []);

  const renderSpaces = (spaces) => {
    return spaces.map(space => (
      <div key={space.name} className="space">
        <strong>{space.name}</strong>
        <div>January: ${space.rentRoll.January}</div>
        <div>February: ${space.rentRoll.February}</div>
      </div>
    ));
  };

  const renderProperty = (property) => (
    <div key={property.id}>
      <h3>{property.name}</h3>
      <div><strong>Features:</strong> {property.features.join(', ')}</div>
      <div><strong>Highlights:</strong> {property.highlights.join(', ')}</div>
      <div><strong>Transportation:</strong> {property.transportation.join(', ')}</div>

      <h4>Spaces</h4>
      <div>{renderSpaces(property.spaces)}</div>
    </div>
  );

  return (
    <div className="property-list">
      {loading ? (
        <p>Loading...</p>
      ) : (
        properties.map(property => (
          <CollapsibleSection key={property.id} title={`Property: ${property.name}`}>
            {renderProperty(property)}
          </CollapsibleSection>
        ))
      )}
    </div>
  );
};

export default PropertyList;
