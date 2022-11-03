import React from "react";
import { Button, Card, ListGroup } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import './Catalog.css';

function CatalogList () {
    const navigation = useNavigate();
    
    return (
        <div className='item'>
            <div className="catalog-item">
                <Card>
                    <Card.Body>
                        <Card.Img variant="top" src="https://www.apple.com/euro/iphone/home/j/screens_alt/images/meta/iphone__ky2k6x5u6vue_og.png"/>
                    </Card.Body>
                    <ListGroup className="list-group-flush">
                        <ListGroup.Item>Phones</ListGroup.Item>
                    </ListGroup>
                    <Card.Body>
                        <Button href="/phones" variant="dark">Click</Button>
                    </Card.Body>
                </Card> 
            </div> 

            <div className="catalog-item">
                <Card>
                    <Card.Body>
                        <Card.Img variant="top" src="https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RWBrzy?ver=85d4&q=90&m=6&h=705&w=1253&b=%23FFFFFFFF&f=jpg&o=f&p=140&aim=true"/>
                    </Card.Body>
                    <ListGroup className="list-group-flush">
                        <ListGroup.Item>Computers</ListGroup.Item>
                    </ListGroup>
                    <Card.Body>
                        <Button href="/computers" variant="dark">Click</Button>
                    </Card.Body>
                </Card> 
            </div> 
        </div>
    );
}

export default CatalogList;