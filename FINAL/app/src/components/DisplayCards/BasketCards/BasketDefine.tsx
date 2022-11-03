import axios from "axios";
import React from "react";
import { Button, Card, ListGroup } from "react-bootstrap";
import { useParams } from "react-router-dom";

interface IPnone{
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number,
    basketId : number
}


function Basket (phones : IPnone[])  {
    
    const deletePhone = (id: number) => {

        const response = fetch('http://localhost:7169/Basket/' + id, {
                method: 'DELETE',
                headers: {
                'Content-Type': 'application/json',
                Accept: 'application/json',
                },
                });
                //       if (!response.ok) {
                //     throw new Error(`Error! status: ${response.status}`);
                // }
      
               // const result = (await response.json());
      
                //console.log('result is: ', response);  

                // alert("it's just deleted");
                // window.location.reload();

    }

    return (
        <div className="items-define">
            <div className="item-define">
                
                {phones.map((phone) => (
                    //console.log("ID CHEKIKIII ", phone.basketId),
                    // console.log("phoneIdPage ", phoneIdPage),
                    
                    <Card key={phone.phoneId} className="phone-single-item">  
                        <Card.Body>
                            <Card.Img variant="top" src={phone.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{phone.name}</ListGroup.Item>
                            {/* <ListGroup.Item>{phone.description}</ListGroup.Item> */}
                            <ListGroup.Item>{phone.price}</ListGroup.Item>
                        </ListGroup>
                        <Card.Body>
                            <Button onClick={() => deletePhone(phone.basketId)} variant="dark">Delete</Button>
                        </Card.Body>
                    </Card> 
                ))}
                
            </div> 
        </div>
    );
}



export default Basket;
function setState(arg0: { status: string; }): any {
    throw new Error("Function not implemented.");
}

