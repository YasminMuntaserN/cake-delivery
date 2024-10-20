import React, { useState } from "react";
import { MapContainer, TileLayer, Marker } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import AddCustomerForm from "../components/customer/AddCustomerForm";

function Map() {
  const [coordinates, setCoordinates] = useState([]);

  const {latitude, longitude}=coordinates;
  const handleGeocode = (position) => {
    setCoordinates(position);
  };
  return (
    <div className="flex ">
      <AddCustomerForm onGeocode={handleGeocode} />
      <div className={StyledContainer}>
        {coordinates.length !== 0 ? (
          <MapContainer center={[latitude, longitude]} zoom={13} className={StyledMap}>
            <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
            <Marker position={[latitude, longitude]} />
          </MapContainer>
        ) : (
          <p>Loading map...</p>
        )}
      </div>
    </div>
  );
}

const StyledContainer = "w-1/2  mx-7 my-10  border-2  rounded-lg p-1";
const StyledMap = "w-full h-full rounded-lg";

export default Map;
