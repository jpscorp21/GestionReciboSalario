import { TestBed } from '@angular/core/testing';

import { ReciboSalariosService } from './recibo-salarios.service';

describe('ReciboSalariosService', () => {
  let service: ReciboSalariosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ReciboSalariosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
