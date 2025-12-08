import React, { useEffect, useState } from "react";

const BookingList = () => {
    const [bookings, setBookings] = useState([]);

    useEffect(() => {
        fetch("/api/bookings")
            .then(res => res.json())
            .then(data => setBookings(data))
            .catch(err => console.error(err));
    }, []);

    return (
        <div>
            <h2>All Bookings</h2>
            <table border="1" cellPadding="5">
                <thead>
                    <tr>
                        <th>hotelNo</th>
                        <th>roomNo</th>
                        <th>guestNo</th>
                        <th>dateFrom</th>
                        <th>dateTo</th>
                    </tr>
                </thead>
                <tbody>
                    {bookings.map(b => (
                        <tr key={b.hoteNo}>
                            <td>{b.hotelNo}</td>
                            <td>{b.roomNo}</td>
                            <td>{b.guestNo}</td>
                            <td>{b.dateFrom?.substring(0, 10)}</td>
                            <td>{b.dateTo?.substring(0, 10)}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default BookingList;
