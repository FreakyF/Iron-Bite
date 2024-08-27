import {MeasurementUnit} from "./measurement-unit";

export interface Quantity {
  value: number;
  unit: MeasurementUnit;
}
