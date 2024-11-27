import React, { useState, useEffect } from 'react';
import {
  Card,
  CardHeader,
  CardContent,
  Accordion,
  AccordionItem,
  AccordionTrigger,
  AccordionContent,
} from '@/components/ui/accordion'; // Ensure this import path is correct

const PropertiesApp = () => {
  const [properties, setProperties] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchProperties = async () => {
      try {
        const response = await fetch('/api/properties'); // Replace with your actual API endpoint
        if (!response.ok) {
          throw new Error('Failed to fetch properties');
        }
        const data = await response.json();
        setProperties(data.properties || []); // Use a fallback in case properties is not defined
        setLoading(false);
      } catch (err) {
        setError(err.message || 'An unexpected error occurred');
        setLoading(false);
      }
    };

    fetchProperties();
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div className="p-4">
      <h1 className="text-2xl font-bold mb-4">Property Listings</h1>
      {properties.length > 0 ? (
        properties.map((property, propertyIndex) => (
          <Accordion type="single" collapsible key={`property-${propertyIndex}`}>
            <AccordionItem value={`property-${propertyIndex}`}>
              <AccordionTrigger>{property.name}</AccordionTrigger>
              <AccordionContent>
                <div className="grid grid-cols-2 gap-4">
                  {/* Property Details */}
                  <Card>
                    <CardHeader>Property Details</CardHeader>
                    <CardContent>
                      <h3>Features</h3>
                      <ul>
                        {property.features?.map((feature, index) => (
                          <li key={`feature-${index}`}>{feature}</li>
                        ))}
                      </ul>
                      <h3>Highlights</h3>
                      <ul>
                        {property.highlights?.map((highlight, index) => (
                          <li key={`highlight-${index}`}>{highlight}</li>
                        ))}
                      </ul>
                      <h3>Transportation</h3>
                      <p>Green Line: {property.transportation?.greenLineDistance || 0} miles</p>
                      <p>Route 15: {property.transportation?.route15Distance || 0} miles</p>
                    </CardContent>
                  </Card>

                  {/* Spaces */}
                  <Card>
                    <CardHeader>Spaces</CardHeader>
                    <CardContent>
                      {property.spaces?.length > 0 ? (
                        property.spaces.map((space, spaceIndex) => (
                          <Accordion
                            type="single"
                            collapsible
                            key={`space-${spaceIndex}`}
                          >
                            <AccordionItem value={`space-${spaceIndex}`}>
                              <AccordionTrigger>{space.name}</AccordionTrigger>
                              <AccordionContent>
                                <h4>Rent Roll</h4>
                                <table className="w-full table-auto border-collapse">
                                  <thead>
                                    <tr>
                                      <th className="border px-4 py-2">Month</th>
                                      <th className="border px-4 py-2">Rent</th>
                                    </tr>
                                  </thead>
                                  <tbody>
                                    {Object.entries(space.rentRoll || {}).map(
                                      ([month, rent]) => (
                                        <tr key={month}>
                                          <td className="border px-4 py-2">{month}</td>
                                          <td className="border px-4 py-2">${rent}</td>
                                        </tr>
                                      )
                                    )}
                                  </tbody>
                                </table>
                              </AccordionContent>
                            </AccordionItem>
                          </Accordion>
                        ))
                      ) : (
                        <p>No spaces available for this property.</p>
                      )}
                    </CardContent>
                  </Card>
                </div>
              </AccordionContent>
            </AccordionItem>
          </Accordion>
        ))
      ) : (
        <p>No properties available.</p>
      )}
    </div>
  );
};

export default PropertiesApp;
