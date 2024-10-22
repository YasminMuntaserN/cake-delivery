import React from "react";
import { MapContainer, TileLayer, Marker } from "react-leaflet";
import "leaflet/dist/leaflet.css";


function Map({coordinates}) {

  const {latitude, longitude}=coordinates;


  return (
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
  );
}

const StyledContainer = "mx-7 my-10  border-2  rounded-lg p-1";
const StyledMap = "w-full h-full rounded-lg";

export default Map;
