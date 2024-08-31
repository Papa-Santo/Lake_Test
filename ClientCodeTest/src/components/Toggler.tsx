import { Form } from "react-bootstrap";
import { I_Option } from "../data/interfaces";

interface I_TitleToggle {
  curVal: string | number;
  setResult: Function;
  options: I_Option[];
  title: string;
  inline?: boolean;
}

const Toggler = (props: I_TitleToggle) => {
  // Dynamic creation of options
  const makeOptions = () =>
    props.options.map((el: I_Option) => (
      <option key={el.id} value={el.id}>
        {el.label}
      </option>
    ));

  return (
    <Form.Group
      className={props.inline ? "d-flex flex-row align-items-center" : ""}
    >
      <Form.Label className={props.inline ? "p-0 mb-0 me-3" : ""}>
        {props.title}:
      </Form.Label>
      <Form.Select
        className={props.inline ? "" : "mb-3"}
        onChange={(e) => props.setResult(e.target.value)}
        value={props.curVal}
      >
        {makeOptions()}
      </Form.Select>
    </Form.Group>
  );
};

export default Toggler;
