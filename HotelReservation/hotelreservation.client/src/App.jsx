import React from "react";
import HotelForm from "./components/HotelForm";
import BookingList from "./components/BookingList";
// import RoomForm, GuestForm, BookingForm when you create them

function App() {
    return (
        <div style={{ padding: "20px" }}>
            <h1>Hotel Booking Management</h1>

            <HotelForm />
            {/* Add RoomForm, GuestForm, BookingForm too */}
            {/* <RoomForm /> */}
            {/* <GuestForm /> */}
            {/* <BookingForm /> */}

            <hr />
            <BookingList />
        </div>
    );
}

export default App;
