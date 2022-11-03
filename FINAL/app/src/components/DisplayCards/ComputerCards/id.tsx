import { MDBCard, MDBCardBody, MDBCardImage, MDBCardText, MDBCardTitle, MDBCol, MDBRow } from "mdb-react-ui-kit";
import React, { useEffect, useState } from "react";
import { Card } from "react-bootstrap";
import { useParams } from "react-router-dom";

interface IComp {
    phoneId: number,
    name: string,
    description: string,
    url: string,
    price: number
}

export default function IdCo (){
    const [phones, setDisplay] = useState<IComp[]>([]);

    const phoneIdPage = useParams();
    console.log("j ", phoneIdPage);
    const entries = Object.values(phoneIdPage);

    let num = 0;
    if (entries[0] != undefined){
        num = parseInt(entries[0]);
    }


    const [arrr, setArr ] = useState<Array<any>>([]);

    const Get = async() : Promise<Array<any>>   => {
        console.log("start ");

        const res: Response =  await fetch(`http://localhost:7169/Phone/${num}`);
        const body = await res.json();

        const ent = Object.values(body);


        setArr(ent);


        return arrr;
        
     }
    
    

    useEffect(() => {
        console.log("aaarrs ", arrr);
        Get();

        console.log("aaarr ", arrr);
        console.log("c ", phones);
    }, []);


    
    return(
        <>
        {/* <MDBCard style={{ maxWidth: '1000px' }}>
      <MDBRow className='g-0'>
        <MDBCol md='4'>
          <MDBCardImage src={arrr[3]} alt='...' fluid />
        </MDBCol>
        <MDBCol md='8'>
          <MDBCardBody>
            <MDBCardTitle>{arrr[1]}</MDBCardTitle>
            <MDBCardText>
            {arrr[2]}
            </MDBCardText>
            <MDBCardText>
            {arrr[4]} $
            </MDBCardText>
            <MDBCardText>
              <small className='text-muted'>{arrr[5]}</small>
              <Card.Link href="/phones">Add</Card.Link>
            </MDBCardText>
          </MDBCardBody>
        </MDBCol>
      </MDBRow>
    </MDBCard> */}
    <div>{arrr[1]}</div>


         

       
        </>
        
    
    );
    // return(
    //     <div>i</div>
    // );
}





