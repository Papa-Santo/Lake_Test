import { I_WorkOrder } from "../data/interfaces";
import { Table } from "react-bootstrap";
import { I_KeyVal } from "../data/options";
import { format, parse } from "date-fns";

interface I_TableListProps {
  list: I_WorkOrder[];
  translationObject?: I_KeyVal;
}

const TableList = (props: I_TableListProps) => {
  const { translationObject, list } = props;

  // Dynamic table creation from list of objects
  const makeTable = () => {
    return (
      <Table striped={true} bordered hover responsive>
        <thead>
          <tr key={"header"}>
            {Object.keys(list[0]).map((el: any) => (
              <th key={el}>{translationObject ? translationObject[el] : el}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {list.map((el: I_WorkOrder, i: number) => {
            return (
              <tr key={i}>
                {Object.entries(el).map((el: [string, any], index: number) => {
                  let info = el[1];
                  // For formatting date times in a readable way
                  if (el[0].indexOf("date") > -1 && el[1]) {
                    info = format(new Date(el[1]), "MM/dd/yyyy kk:mm");
                  }
                  return <td key={index}>{info}</td>;
                })}
              </tr>
            );
          })}
        </tbody>
      </Table>
    );
  };

  return <>{props.list.length > 0 ? makeTable() : <h3>No Data</h3>}</>;
};

export default TableList;
