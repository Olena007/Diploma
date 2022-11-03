import React from "react";
import { Link } from "react-router-dom";

const Header = (props: { name: string, setName: (name: string) => void }) => {
    const logout = async () => {
        await fetch('http://localhost:7169/api/logout', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            credentials: 'include',
        });

        
        props.setName('');
        //console.log("it's null or not ?", props.name);
    }

    let menu;
    let count = 0;

    if (props.name === '' ) {
        menu = (
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
                <li className="nav-item active">
                    <Link to="/login" className="nav-link">Login</Link>
                </li>
                <li className="nav-item active">
                    <Link to="/register" className="nav-link">Register</Link>
                </li>
            </ul>
        )

        // console.log("props.name in Login/Register -", "'", props.name, "'");
    } 
    else
    if ( props.name != '') {
        menu = (
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
                <li className="nav-item active">
                    <Link to="/login" className="nav-link" onClick={logout}>Logout</Link>
                </li>
                <li className="nav-item active">
                    <Link to="/register" className="nav-link">Register</Link>
                </li>
            </ul>
        )

        // console.log("props.name in Logout -", "'", props.name, "'");
    }

    return (
        <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
            <div className="container-fluid">
                <Link to="/" className="navbar-brand">Home</Link>
                <Link to="/catalog" className="navbar-brand">Catalog</Link>
                <Link to="/basket" className="navbar-brand">Basket</Link>
                <div>
                    {menu}
                </div>
            </div>
        </nav>
    );
};

export default Header;