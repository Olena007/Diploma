import React from "react";
import { Card, ListGroup } from "react-bootstrap";
import './CompCards.css';

interface IPnone{
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}
function func(a: number) :string{	
    var str = window.location.href = "/phones/" + a;
    return str;
}

function Phones (phones : IPnone[], loading : boolean)  {
    if(loading){
        return <h2>Loading</h2>
    }

    return (
        <div className="items-define">
            <div className="item-define">
                
                {phones.map((phone) => (
                    
                    <Card key={phone.phoneId} className="phone-single-item">  
                        <Card.Body>
                            <Card.Img variant="top" src={phone.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{phone.name}</ListGroup.Item>
                            <ListGroup.Item>{phone.description}</ListGroup.Item>
                            <ListGroup.Item>{phone.price}</ListGroup.Item>
                        </ListGroup>
                        <Card.Body>
                            <Card.Link href="/phones">Add</Card.Link>
                            <Card.Link onClick={() => window.open(func(phone.phoneId))}>More</Card.Link>
                        </Card.Body>
                    </Card> 
                ))}
                
            </div> 
        </div>
    );
}



export default Phones;