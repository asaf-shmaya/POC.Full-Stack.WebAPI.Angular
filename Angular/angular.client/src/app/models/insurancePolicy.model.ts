export interface InsurancePolicy {
  id: number; // unique policy identifier
  policyNumber: string;
  insuranceAmount: number;
  startDate: Date;
  endDate: Date;
  userId: number; // reference to the user ID
}
