import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { vehicleCategory} from './../Models/vehicleCategory';
import { Router } from '@angular/router';
@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html'
})
export class VehicleComponent {
  public vehicles: Vehicle[];
  public vehicleTypes: vehicleCategory[];
  selectedVehicleType: number;
  constructor(
    http: HttpClient,
    private router: Router,
    @Inject('BASE_URL') baseUrl: string) {
    http.get<vehicleCategory[]>(baseUrl + 'VehicleCategoryMasters').subscribe(result => {
      debugger;
      this.vehicleTypes = result;
      console.log(this.vehicleTypes);      
    }, error => console.error(error));    
  }
  onVehicleSelection(data) {
    this.selectedVehicleType = data.value;
    console.log('success' + data.value);
  }
  goToCreateVehicle() {
    this.router.navigate(['vehicle/create'], {
      queryParams: { vehicleType: this.selectedVehicleType }
    });
  }
}

interface Vehicle {
  id: string;
  make: number;
  model: number;
  engine: string;
  doors: number;
  wheels: number;
  vehicleTypeId: number;
  bodyTypeId: number;
}
