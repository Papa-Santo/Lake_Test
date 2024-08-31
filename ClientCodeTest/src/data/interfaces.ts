export interface I_CreateWorkOrder {
  problem?: string;
  contactnumber?: string;
  contactname?: string;
  email?: string;
  technicianid?: string | number | null;
}

export interface I_WorkOrder extends I_CreateWorkOrder {
  wonum: number;
  status: string;
  datereceived: string;
  dateassigned?: string;
  datecomplete?: string;
  contactname?: string;
  techniciancomments?: string;
}

export interface I_Technician {
  technicianid: number;
  technicianname: string;
  technicianemail: string;
}

export interface I_Option {
  id: string | number;
  label: string;
}
