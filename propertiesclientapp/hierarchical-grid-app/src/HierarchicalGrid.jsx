import React, { useState } from 'react';

const CollapsibleSection = ({ title, children }) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <div>
      <button onClick={() => setIsOpen(!isOpen)}>
        {isOpen ? 'Hide' : 'Show'} {title}
      </button>
      {isOpen && <div>{children}</div>}
    </div>
  );
};

export default CollapsibleSection;