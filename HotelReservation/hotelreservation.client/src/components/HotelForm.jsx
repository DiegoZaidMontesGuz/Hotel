import React, { useState } from "react";

const HotelForm = () => {
    const [form, setForm] = useState({
        name: "",
        address: "",
        city: ""
    });

    const handleChange = e => {
        const { name, value } = e.target;
        setForm(prev => ({ ...prev, [name]: value }));
    };

    const handleSubmit = e => {
        e.preventDefault();

        fetch("/api/hotels", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(form)
        })
            .then(res => {
                if (!res.ok) throw new Error("Failed to save hotel");
                return res.json();
            })
            .then(data => {
                alert("Hotel saved with id: " + data.hotelId);
                setForm({ name: "", address: "", city: "" });
            })
            .catch(err => alert(err.message));
    };

    return (
        <div>
            <h2>Add Hotel</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Name: </label>
                    <input name="name" value={form.name} onChange={handleChange} />
                </div>
                <div>
                    <label>Address: </label>
                    <input name="address" value={form.address} onChange={handleChange} />
                </div>
                <div>
                    <label>City: </label>
                    <input name="city" value={form.city} onChange={handleChange} />
                </div>
                <button type="submit">Save Hotel</button>
            </form>
        </div>
    );
};

export default HotelForm;
