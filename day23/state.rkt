#lang racket

(provide string->state
         display-state
         is-occupied)

#|

state is a vector of length 19
index ranges from 0 - 18

+-------------------------------------------+
| 0   1   2   3   4   5   6   7   8   9  10 |
+-----+  11   |  13   |  15   |  17   +-----+
      |  12   |  14   |  16   |  18   |
      +-------------------------------+

Possible values:

.  empty space
A  Amber amphipod (1 energy per step)
B  Bronze amphipod (10 energy per step)
C  Copper amiphod (100 energy per step)
D  Desert amiphod (1,000 energy per step)

|#


(define (string->state str)
  (list->vector (map string (string->list str))))

(define (display-state state)
  (displayln "+-----------+")
  (display "|")
  (for ((n (in-range 0 11)))
    (display (vector-ref state n)))
  (displayln "|")
  (display "+-+")
  (display (vector-ref state 11))
  (display "|")
  (display (vector-ref state 13))
  (display "|")
  (display (vector-ref state 15))
  (display "|")
  (display (vector-ref state 17))
  (displayln "+-+")
  (display "  |")
  (display (vector-ref state 12))
  (display "|")
  (display (vector-ref state 14))
  (display "|")
  (display (vector-ref state 16))
  (display "|")
  (display (vector-ref state 18))
  (displayln "|  ")
  (displayln "  +-------+  "))

;; #t if state is occupied at index
;; #f if state is empty at index
(define (is-occupied state index)
  (not (equal? (vector-ref state index) ".")))
