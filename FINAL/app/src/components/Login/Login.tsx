import React, { SyntheticEvent, useState } from "react";
import "react-bootstrap";
import { Button } from "react-bootstrap";
import { Navigate } from "react-router-dom";
 import './Login.css';

const Login = (props: { setName: (name: string) => void }) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const[redirect, setRedirect] = useState(false);


    const submit = async (e : SyntheticEvent) => {
        e.preventDefault();
        
        const responce = await fetch ('http://localhost:7169/api/login', {
            mode: 'cors',
            method: 'POST',
            headers: {'Content-Type': 'application/json', 'Accept' : 'application/json'},
            credentials: 'include',
            body: JSON.stringify( {
                email,
                password
            })
        });
 
        console.log(responce);
        const content = await responce.json();

        props.setName(content.name);

        setRedirect(true);


    }

    if(redirect){
        return <Navigate to="/"/>;
    }
    
    return (
        <div className="form-login">
            <form onSubmit={submit}>
                <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
                <input type="email" className="form-control" placeholder="Email address" required 
                onChange={e => setEmail(e.target.value)}/>

                <input type="password" className="form-control" placeholder="Password" required 
                onChange={e => setPassword(e.target.value)}/>

                <Button className="w-100 btn btn-lg btn-primary" variant="success" type="submit">Sign in</Button>
                
            </form>
        </div>
        
    );
}

export default Login; 