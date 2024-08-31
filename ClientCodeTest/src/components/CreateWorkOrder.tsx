import { SyntheticEvent, useRef, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { I_CreateWorkOrder, I_Option } from "../data/interfaces";
import Toggler from "./Toggler";

interface I_CreateWorkOrderProps {
  submitFunc: Function;
  techs: I_Option[];
}

const CreateWorkOrder = (props: I_CreateWorkOrderProps) => {
  // Using refs limits rerenders
  const contactNameRef = useRef<HTMLInputElement | null>(null);
  const contactNumberRef = useRef<HTMLInputElement | null>(null);
  const emailRef = useRef<HTMLInputElement | null>(null);
  const problemRef = useRef<HTMLInputElement | null>(null);

  // The tech id component reuses the Toggler component
  // This component was set up to be a controled component and uses state
  const [techId, setTechId] = useState<string | number>(props.techs[0].id);

  const doSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const formInfo: I_CreateWorkOrder = {
      contactname: contactNameRef.current?.value,
      problem: problemRef.current?.value,
      contactnumber: contactNumberRef.current?.value,
      email: emailRef.current?.value,
      technicianid: techId,
    };
    props.submitFunc(formInfo);
  };

  return (
    <Form onSubmit={doSubmit}>
      <Form.Group className="mb-3" controlId="email">
        <Form.Label>Email</Form.Label>
        <Form.Control type="email" placeholder="" ref={emailRef} required />
      </Form.Group>
      <Form.Group className="mb-3" controlId="contactname">
        <Form.Label>Contact Name</Form.Label>
        <Form.Control type="text" placeholder="" ref={contactNameRef} />
      </Form.Group>
      <Form.Group className="mb-3" controlId="contactnumber">
        <Form.Label>Contact Number</Form.Label>
        <Form.Control type="text" placeholder="" ref={contactNumberRef} />
      </Form.Group>
      <Form.Group className="mb-3" controlId="problem">
        <Form.Label>Problem</Form.Label>
        <Form.Control type="text" placeholder="" ref={problemRef} />
      </Form.Group>
      <Toggler
        setResult={setTechId}
        curVal={techId}
        options={props.techs}
        title="Technician"
      />
      <div className="d-grid gap-2 mt-4">
        <Button variant="primary" type="submit">
          Submit
        </Button>
      </div>
    </Form>
  );
};

export default CreateWorkOrder;
