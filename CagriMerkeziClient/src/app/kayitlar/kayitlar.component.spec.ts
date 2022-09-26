import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KayitlarComponent } from './kayitlar.component';

describe('KayitlarComponent', () => {
  let component: KayitlarComponent;
  let fixture: ComponentFixture<KayitlarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KayitlarComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KayitlarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
