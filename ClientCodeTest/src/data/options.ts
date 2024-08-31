import { I_Option, I_Technician } from "./interfaces";

export const statusOptions: I_Option[] = [
  { id: "All", label: "All" },
  { id: "Open", label: "Open" },
  { id: "Assigned", label: "Assigned" },
  { id: "Closed", label: "Closed" },
];

export const techArrToIOptions = (techArr: I_Technician[]) =>
  techArr.map((el: I_Technician) => {
    return { id: el.technicianid, label: el.technicianname };
  });

export interface I_KeyVal {
  [key: string]: string;
}

export const workOrderTranslations: I_KeyVal = {
  contactname: "Contact Name",
  contactnumber: "Contact Number",
  dateassigned: "Date Assigned",
  datecomplete: "Date Completed",
  datereceived: "Date Received",
  email: "Email",
  problem: "Problem",
  status: "Status",
  techniciancomments: "Technician Comments",
  technicianid: "Technician Id",
  wonum: "WO Number",
};
