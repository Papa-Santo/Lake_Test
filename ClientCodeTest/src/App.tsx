import { useEffect, useState } from "react";
import { appGet, appPost } from "./api/appFetch";
import CreateWorkOrder from "./components/CreateWorkOrder";
import ModalDisplay from "./components/ModalDisplay";
import {
  I_CreateWorkOrder,
  I_Technician,
  I_WorkOrder,
} from "./data/interfaces";
import TableList from "./components/TableList";
import Toggler from "./components/Toggler";
import {
  statusOptions,
  techArrToIOptions,
  workOrderTranslations,
} from "./data/options";
import { Button } from "react-bootstrap";
import "./assets/bootstrap.min.css";

const App = () => {
  const [showModal, setShowModal] = useState<boolean>(false);
  const [list, setList] = useState<I_WorkOrder[]>([]);
  const [techs, setTechs] = useState<I_Technician[]>([]);
  const [status, setStatus] = useState<string>("Open");

  useEffect(() => {
    getWorkOrders(status);
    getTechnicians();
  }, []);

  // API Calls
  // There was no error reporting in the assignment so errors are handled with console.logs
  const getWorkOrders = async (status: string) => {
    let getPath: string = "WorkOrders";
    if (status !== "All") getPath = `${getPath}/Status`;
    try {
      const res = await appGet(getPath, { status });
      setList(res);
    } catch (err) {
      console.log(err);
    }
  };

  const getTechnicians = async () => {
    try {
      const res = await appGet("Technician");
      setTechs(res);
    } catch (err) {
      console.log(err);
    }
  };

  const createWorkOrder = async (formInfo: I_CreateWorkOrder) => {
    try {
      await appPost("WorkOrders", formInfo);
      setShowModal(false);
      getWorkOrders(status);
    } catch (err) {
      console.log(err);
    }
  };

  const makeStatusChange = (statusChange: string) => {
    setStatus(statusChange);
    getWorkOrders(statusChange);
  };

  return (
    <div className="container mt-5">
      <div className="mb-3">
        <h1>Work Orders</h1>
      </div>
      <div className="d-flex flex-row mb-3 justify-content-between">
        <Toggler
          setResult={makeStatusChange}
          curVal={status}
          options={statusOptions}
          title="Status"
          inline={true}
        />
        <Button variant="primary" onClick={() => setShowModal(true)}>
          Add Work Order
        </Button>
      </div>
      <TableList list={list} translationObject={workOrderTranslations} />
      {showModal && (
        <ModalDisplay
          show={showModal}
          setShow={setShowModal}
          title="Create A Work Order"
        >
          <CreateWorkOrder
            submitFunc={createWorkOrder}
            techs={techArrToIOptions(techs)}
          />
        </ModalDisplay>
      )}
    </div>
  );
};

export default App;
