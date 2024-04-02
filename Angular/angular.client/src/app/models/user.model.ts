import { InsurancePolicy } from './insurancePolicy.model'; // Import statement to reference the InsurancePolicy interface

export interface User {
  id: number; // unique user identifier
  name: string;
  email: string;
  insurancePolicies: InsurancePolicy[];  // array of insurance policies
}

