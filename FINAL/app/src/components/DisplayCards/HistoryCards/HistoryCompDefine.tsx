import React from "react";
import { Card, ListGroup } from "react-bootstrap";

interface IBasketComp{
    historyId : number
    computerId: number,
    name: string,
    description: string,
    url: string,
    price: number,
}

export default function HistoryComp(baskets : IBasketComp[]){
    return (
        <div className="items-define">
            <div className="item-define">
                {baskets.map((basket) => (                    
                    <Card key={basket.historyId} className="phone-single-item">  
                        <Card.Body>
                            <Card.Img variant="top" src={basket.url} style={{width: '400px'}}/>
                        </Card.Body>
                        <ListGroup className="list-group-flush">
                            <ListGroup.Item>{basket.name}</ListGroup.Item>
                            <ListGroup.Item>{basket.price}</ListGroup.Item>
                        </ListGroup>
                    </Card> 
                ))}
                
            </div> 
        </div>
    );
}