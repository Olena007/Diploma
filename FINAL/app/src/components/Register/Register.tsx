import React, { SyntheticEvent, useState } from "react";
import { Button } from "react-bootstrap";
import { Navigate, Route } from "react-router-dom";

import './Register.css';


const Register = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const[redirect, setRedirect] = useState(false);

    const submit = async (e : SyntheticEvent) => {
        e.preventDefault();
        
        const responce = await fetch ('http://localhost:7169/api/register', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify( {
                email,
                password
            })
        });

        setRedirect(true);

    }

    if(redirect){
        return <Navigate to="/login"/>;
    }

    


    return(
            <div className="form-register">
               
            <form onSubmit={submit} className="form-register-center">
                <h1 className="h3 mb-3 fw-normal">Please register</h1>
                <input type="email" className="form-control" placeholder="Email address" required  
                onChange={e => setEmail(e.target.value)}
                />

                <input type="password" className="form-control" placeholder="Password" required 
                onChange={e => setPassword(e.target.value)}
                />

                <Button className="w-100 btn btn-lg btn-primary" variant="success" type="submit">Submit</Button>
                
            </form>
        </div>
    );
}

export default Register;